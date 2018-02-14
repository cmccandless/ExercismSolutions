from io import StringIO
import os
import subprocess as sp
import sys


def log(msg, label=None):
    try:
        import __main__
        main_file = __main__.__file__
    except AttributeError:
        main_file = '<SHELL>'
    if label is not None:
        msg = '[{}] {}'.format(label, msg)
    print('{}: {}'.format(main_file, msg), flush=True)


def abort(msg='', label=None):
    log('Aborting commit: {}'.format(msg), label)
    sys.exit(1)


def exec(*args, quiet=True, label=None, shell=False):
    try:
        with sp.Popen(args, stdout=sp.PIPE, bufsize=1, shell=shell,
                      universal_newlines=True) as p, StringIO() as buf:
            for line in p.stdout:
                if not quiet:
                    log(line, label)
                buf.write(line)
            output = buf.getvalue().strip()
        return (output, p.returncode)
    except FileNotFoundError as e:
        abort('[{}] Not found: {}'.format(' '.join(args), e.filename), label)


def linter(track, quiet=True):
    shell = False
    if track in ['python', 'hooks']:
        args = ['flake8', track]
    elif track == 'haskell':
        args = ['hlint', track]
    else:
        return ('No available linter for "{}"'.format(track), 0)
    return exec(*args, quiet=quiet, label=track, shell=shell)


def runner(track, exercise, quiet=True):
    label = '{}/{}'.format(track, exercise)
    shell = False
    if track in ['cpp', 'powershell']:
        return (None, 0)
    if track == 'csharp':
        args = ['dotnet', 'test']
        shell = True
    elif track == 'go':
        args = ['go', 'test']
    elif track == 'haskell':
        args = ['stack', '--silent', 'test']
    elif track == 'java':
        args = ['gradle', 'test', '-Dfile.encoding=utf-8']
        shell = True
    elif track == 'python':
        args = ['pytest', '-q']
    elif track == 'ruby':
        args = ['ruby', '{}_test.rb'.format(exercise.replace('-', '_'))]
    else:
        return ('unknown track "{}"'.format(track), -1)
    return exec(*args, quiet=quiet, label=label, shell=shell)


def get_current_branch():
    branch, ret = exec('git', 'symbolic-ref', '-q', 'HEAD')
    if ret != 0:
        abort('git-symbolic-ref: error {} occurred'.format(ret))
    branch = branch.replace('refs/heads/', '')
    if branch == '':
        branch = 'HEAD'
    return branch


def get_exercises(track):
    ignore = {'__pycache__', '.vs', '.vscode', 'bin', 'obj', 'Properties'}
    results = []
    base_path = os.path.join(os.getcwd(), track)
    for exercise in os.listdir(base_path):
        if exercise in ignore:
            continue
        if os.path.isdir(os.path.join(base_path, exercise)):
            results.append(exercise)
    return results


def get_changed_exercises(commit=-1):
    args = ['git', 'diff', '--name-status']
    if commit < 0:
        args.append('--cached')
    else:
        args.append('HEAD~{}'.format(commit + 1))
        args.append('HEAD~{}'.format(commit))
    changes, ret = exec(*args)
    changes = changes.split('\n')
    if ret != 0:
        abort('error {} occurred'.format(ret), 'git-diff')
    changed_exercises = set()
    for change in changes:
        if change == '':
            continue
        change_type, *fileparts = change.split()
        filename = ' '.join(fileparts).strip()
        if change_type == 'D' or '/' not in filename:
            continue
        track, exercise, *_ = filename.split('/')
        changed_exercises.add((track, exercise))
    return changed_exercises


def get_git_root():
    git_root, ret = exec('git rev-parse --show-toplevel')
    return git_root if ret == 0 else None
