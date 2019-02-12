#!/bin/bash

grep -oP '(?<=submodule ").+(?=")' .gitmodules
