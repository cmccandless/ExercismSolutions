import glob
from os import path, getcwd, sep, system, listdir, remove
from sys import argv, exit
from shutil import copy2


def printUsage():
    print('Usage:')
    print('    From exercise directory: update.py')
    print('    From track directory: update.py <exercise>')
    print('    From root directory: update.py <track> <exercise>')


def update(track, exercise, cwd=None, quiet=True):
    def log(msg):
        if not quiet:
            print(msg)
    if cwd is None:
        cwd = getcwd()
    log('Track: {}'.format(track))
    log('Exercise: {}'.format(exercise))
    log(cwd)
    testFile = '{}Test.cs'.format(exercise.title().replace('-', ''))
    for item in listdir(cwd):
        name = path.join(cwd, item)
        if not path.isfile(name):
            continue
        if name.endswith('Test.cs'):
            log('Removing test file "{}"...'.format(item))
            testFile = name
            remove(name)
        elif name.endswith('.csproj'):
            log('Removing project file "{}"...'.format(item))
            remove(name)
        elif name.endswith('.cs'):
            log('Backing up source file "{}"...'.format(item))
            copy2(name, name + '.bak')
    system('exercism f {} {}'.format(track, exercise))
    if not path.isfile(testFile):
        matches = glob.glob('*Test.cs')
        if any(matches):
            testFile = matches[0]
    if path.isfile(testFile):
        with open(testFile, 'r') as f:
            tests = f.read()
        tests = tests.replace('(Skip = "Remove to run test")', '')
        with open(testFile, 'w') as f:
            f.write(tests)
    else:
        log('Cannot locate test file "{}"'.format(testFile))
    for item in listdir(cwd):
        name = path.join(cwd, item)
        if not path.isfile(name):
            continue
        if name.endswith('.bak'):
            log('Restoring backed up source file "{}"...'.format(item))
            copy2(name, name.replace('.bak', ''))
            remove(name)
    log('Done.')


if __name__ == '__main__':
    cwd = getcwd()
    parts = cwd.split(sep)
    exercise = parts[-1]
    track = parts[-2]
    if track == 'ExercismSolutions':
        track = exercise
        if len(argv) < 2:
            printUsage()
            exit(1)
        exercise = argv[1]
        cwd = path.join(cwd, exercise)
    elif exercise == 'ExercismSolutions':
        if len(argv) < 3:
            if len(argv) == 2 and path.isdir(argv[1]):
                track, exercise = argv[1].split(sep)
            else:
                printUsage()
                exit(1)
        else:
            track = argv[1]
            exercise = argv[2]
        cwd = path.join(cwd, track, exercise)
    update(track, exercise, cwd, quiet=False)
