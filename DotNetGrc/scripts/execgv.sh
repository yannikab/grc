#!/bin/bash

# modules: graphviz
MODULE="graphviz"

# actions: cstsimple, cst, ast
ACTION="ast"

if [ $# -ne 1 ]; then exit 1; fi

INFILE=$1

if ! echo ${INFILE} | grep -q '.*\.grc$'; then exit 1; fi

OUTFILE=`echo ${INFILE} | sed s:grc\$:${MODULE}.${ACTION}.png:`

echo -n "${INFILE} -> " | sed s://*:/:g

echo ${OUTFILE} | sed s://*:/:g

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source ${DIR}/grc.cfg

${GRC} ${MODULE} ${ACTION} ${INFILE} | cat | dot -Tpng >${OUTFILE}
