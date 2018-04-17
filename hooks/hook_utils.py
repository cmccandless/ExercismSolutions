#!/usr/bin/env python3.6
from __future__ import print_function
from io import StringIO
import os
import subprocess as sp
import sys
from argutil import WorkingDirectory
import git

repo = git.Repo()


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
    log('Aborting: {}'.format(msg), label)
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
    with WorkingDirectory(track):
        args = ['make', 'lint']
        return exec(*args, quiet=quiet, label=track)


def runner(track, exercise, quiet=True):
    make_args = {
        'python': ('-q', exercise),
        'haskell': ('--silent', exercise),
    }
    label = '{}/{}'.format(track, exercise)
    shell = False
    if track in ['cpp', 'powershell']:
        return (None, 0)
    else:
        opts, files = make_args.get(track, ('', exercise))
        args = [
            'make',
            'test',
            'OPTS="{}"'.format(opts),
            'FILES="{}"'.format(files)
        ]
        return exec(*args, quiet=quiet, label=label, shell=shell)
    return exec(*args, quiet=quiet, label=label, shell=shell)


def get_current_branch():
    return repo.active_branch.name


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


def get_changes(commit=-1):
    if commit < 0:
        diffs = repo.index.diff(None, staged=True)
    else:
        left = 'HEAD~{}'.format(commit + 1)
        right = 'HEAD~{}'.format(commit)
        diffs = repo.commit(left).diff(repo.commit(right))
    return diffs


def get_changed_exercises(commit=-1):
    diffs = get_changes(commit)
    changed_exercises = set()
    for d in diffs:
        if d.change_type == 'D' or '/' not in d.b_path:
            continue
        track, exercise = d.a_path.split('/')[:2]
        changed_exercises.add((track, exercise))
    return changed_exercises


def get_git_root():
    return repo.working_dir
