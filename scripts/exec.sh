#!/bin/bash

# modules: lex | parse
MODULE="parse"

# actions: cst | ast
ACTION="ast"

if [ $# -ne 1 ]; then exit; fi

if ! echo $1 | grep -q '.*\.grc$'; then exit; fi

./grc $MODULE $ACTION $1
