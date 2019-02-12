#!/bin/bash

make "$1"
ret="$?"
if [ "$ret" -eq 2 ]; then
    make all
    ret="$?"
    if [ "$ret" -eq 2 ]; then
        echo "make"
        make
        ret="$?"
    fi
fi
exit $ret
