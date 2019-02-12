#!/bin/bash

TRAVIS_BASE="https://travis-ci.com/cmccandless/ExercismSolutions"

track_title()
{
    track="$1"
    grep -oP '(?<=Solutions to Exercism: ).+(?= Track)' "$track/README.md"
}

track_timestamp()
{
    track="$1"
    cd "$track"
    git show -s --format=%ci HEAD
    cd - &> /dev/null
}

echo '# ExercismSolutions'
echo 'My solutions to problems found on Exercism.io'
echo
echo '## Solutions Status'
echo
echo '| Track | Last Updated | Status |'
echo '| --- | --- | --- |'
for track in $(bash bin/lstracks.sh); do
    title="$(track_title "$track")"
    timestamp="$(track_timestamp "$track")"
    if [ -f "$track/.travis.yml" ]; then
        url="${TRAVIS_BASE}-${track}"
        badge="[![Build Status](${url}.svg?branch=master)](${url})"
    else
    # TODO: appveyor?
        badge='*N/A*'
    fi
    printf "| %s | %s | %s |\n" "$title" "$timestamp" "$badge"
done
