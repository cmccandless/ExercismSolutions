#!/bin/bash

hook="$1"

targets="$(grep -E '^[^:]+:[^=]' Makefile | cut -d':' -f1)"
# echo "$targets"

if grep -q "$hook" <<<"$targets"; then
    make "$hook"
else
    if grep -q 'all' <<<"$targets"; then
        make all
    else
        make
    fi
fi
exit "$?"
