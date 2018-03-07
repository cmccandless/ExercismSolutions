#!/usr/bin/env python
import argparse
import os
from glob import glob
from urllib.request import urlretrieve
from urllib.error import HTTPError


parser = argparse.ArgumentParser(
    formatter_class=argparse.ArgumentDefaultsHelpFormatter
)
parser.add_argument('--track', default='*', help=' ')
parser.add_argument('--only', help='exercises to update', default='*')
parser.add_argument('--tests', default='{exercise}_test.py',
                    dest='tests', help=' ')
parser.add_argument(
    '--exclude',
    default=['hooks', 'parallel-letter-frequency'],
    nargs='+',
    help=' '
)

url_fmt = (
    'https://raw.githubusercontent.com/exercism/{track}/'
    'master/exercises/{exercise}/{tests}'
)

opts = parser.parse_args()

for track in filter(os.path.isdir, glob(opts.track)):
    if any(track in glob(ex) for ex in opts.exclude):
        continue
    for exercise in filter(
        os.path.isdir,
        glob(os.path.join(track, opts.only))
    ):
        if any(exercise in glob(os.path.join(track, ex))
               for ex in opts.exclude):
            continue
        if exercise in glob(os.path.join(track, opts.only)):
            env = dict(
                track=track,
                exercise=os.path.basename(exercise)
            )
            env['tests'] = opts.tests.format(**env).replace('-', '_')
            url = url_fmt.format(**env)
            print('Updating {}...'.format(exercise))
            try:
                urlretrieve(
                    url,
                    filename=os.path.join(exercise, env['tests'])
                )
            except HTTPError as e:
                if e.code == 404:
                    print(e.filename, 'could not be downloaded!')
                else:
                    raise
            try:
                urlretrieve(
                    url,
                    filename=os.path.join(exercise, 'README.md')
                )
            except HTTPError as e:
                if e.code == 404:
                    print(e.filename, 'could not be downloaded!')
                else:
                    raise
