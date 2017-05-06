#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

MODULE="graphviz"

# actions: cstsimple | cst | cst2ast | ast
ACTION="ast"

if [ $# -ne 1 ]; then exit; fi

if ! echo $1 | grep -q '.*\.grc$'; then exit; fi

INFILE=$1
OUTFILE=`echo $1 | sed s:grc\$:${MODULE}.${ACTION}.png:`

echo -n "${INFILE} -> " | sed s://:/:

echo ${OUTFILE} | sed s://:/:

${DIR}/grc ${MODULE} ${ACTION} $1 | cat | dot -Tpng >${OUTFILE}
