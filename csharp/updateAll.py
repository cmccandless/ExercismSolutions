#!/c/Python36/python

import os
import subprocess as sp
import sys
from update import update


def run_tests(exercise, quiet=False):
    if quiet:
        args = ['dotnet', 'test', '-v', 'quiet']
    else:
        args = ['dotnet', 'test', '-v', 'minimal']
    return sp.call(args, shell=True) == 0


def main(*args):
    quiet = '-q' in args or '-qf' in args
    force = '-f' in args or '-qf' in args
    track = 'csharp'
    print('Updating', track)
    exercises = [d for d in os.listdir('.')
                 if os.path.isdir(d) and d[0] not in '._' and
                 d not in ['bin', 'obj', 'Properties']]
    need_changes = False
    for exercise in exercises:
        print(exercise)
        os.chdir(exercise)
        if force or not run_tests(exercise, quiet=True):
            msg = 'Tests failed for {}'.format(os.getcwd())
            msg += '\nResolve outdated code and press ENTER'
            update(track, exercise)
            choice = None
            while choice not in ['s', 'q'] and not run_tests(exercise, quiet):
                if quiet:
                    if not need_changes:
                        need_changes = True
                        with open('update.log', 'w') as f:
                            _msg = 'The following exercises require changes:\n'
                            f.write(_msg)
                    with open('update.log', 'a') as f:
                        f.write('{}\n'.format(exercise))
                    choice = 's'
                else:
                    choice = input(msg)
            if choice == 'q':
                sys.exit(0)
        os.chdir('..')
    if quiet and not need_changes:
        with open('update.log', 'w') as f:
            f.write('No exercises requiring changes.\n')


if __name__ == '__main__':
    main(*sys.argv[1:])
