#!/bin/bash

MODE="cst"

if [ $# -ne 1 ]; then exit; fi

if ! echo $1 | grep -q '.*\.grc$'; then exit; fi

./grc parse $MODE $*
