from io import StringIO
import subprocess as sp
import sys


def log(msg, label=None):
    if label is not None:
        msg = '[{}] {}'.format(label, msg)
    print('pre-commit: {}'.format(msg), flush=True)


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


def runner(track, exercise, quiet=True):
    label = '{}/{}'.format(track, exercise)
    shell = False
    if track in ['cpp', 'powershell']:
        return (None, 0)
    if track == 'csharp':
        args = ['dotnet', 'test']
    elif track == 'go':
        args = ['go', 'test']
    elif track == 'haskell':
        args = ['stack', '--silent', 'test']
    elif track == 'java':
        args = ['gradle', 'test']
        shell = True
    elif track == 'python':
        args = ['pytest', '-q']
    elif track == 'ruby':
        args = ['ruby', '{}_test.rb'.format(exercise)]
    return exec(*args, quiet=quiet, label=label, shell=shell)


def get_current_branch():
    branch, ret = exec('git', 'symbolic-ref', '-q', 'HEAD')
    if ret != 0:
        abort('git-symbolic-ref: error {} occurred'.format(ret))
    branch = branch.replace('refs/heads/', '')
    if branch == '':
        branch = 'HEAD'
    return branch


def get_changed_exercises():
    changes, ret = exec('git', 'diff', '--cached', '--name-status')
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
