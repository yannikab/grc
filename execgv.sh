#!/bin/bash

MODE="ast"

if [ $# -ne 1 ]; then exit; fi

if ! echo $1 | grep -q '.*\.grc$'; then exit; fi

./grc graphviz $MODE $1 | dot -Tpng >`echo $1 | sed s/grc/png/`
