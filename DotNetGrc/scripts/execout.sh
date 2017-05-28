#!/bin/bash

# modules: lex, parse, type, code
MODULE="code"

# actions:
# lex -> -
# parse -> cst, ast
# type -> -
# code -> tac
ACTION="tac"

if [ $# -ne 1 ]; then exit 1; fi

INFILE=$1

if ! echo ${INFILE} | grep -q '.*\.grc$'; then exit 1; fi

OUTFILE=`echo ${INFILE} | sed s:grc\$:${MODULE}.${ACTION}.txt:`

echo -n "${INFILE} -> " | sed s://*:/:g

echo ${OUTFILE} | sed s://*:/:g

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source ${DIR}/grc.cfg

${GRC} ${MODULE} ${ACTION} ${INFILE} >${OUTFILE}
