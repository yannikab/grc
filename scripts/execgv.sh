#!/bin/bash

MODULE="graphviz"

# actions: cstsimple | cst | cst2ast | ast
ACTION="ast"

if [ $# -ne 1 ]; then exit; fi

if ! echo $1 | grep -q '.*\.grc$'; then exit; fi

./grc $MODULE $ACTION $1 | dot -Tpng >`echo $1 | sed s/grc/${MODULE}.${ACTION}.png/`
