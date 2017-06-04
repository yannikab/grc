#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# modules: lex | parse
MODULE="parse"

# actions: cst | ast
ACTION="ast"

if [ $# -ne 1 ]; then exit; fi

if ! echo $1 | grep -q '.*\.grc$'; then exit; fi

INFILE=$1
echo ${INFILE} | sed s://:/:

${DIR}/grc $MODULE $ACTION $1
