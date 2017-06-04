#!/bin/bash

# modules: lex, parse, type, code
MODULE="code"

# actions:
# lex -> ""
# parse -> cst, ast
# type -> ""
# code -> src, srcll, tac, tacll, cil
ACTION="tacll"

if [ $# -ne 1 ]; then exit 1; fi

INFILE="`echo $1 | sed s://*:/:g`"

if ! echo ${INFILE} | grep -q '.*\.grc$'; then exit 1; fi

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

[ ! -x "${GRC}" ] && ("${DIR}"/build.sh; echo)

if [ ${ENV} = 'DotNet' ]
then
	[ `echo $ACTION | wc -w` = 1 -o $MODULE = 'lex' -o $MODULE = 'type' ] && "${GRC}" ${MODULE} ${ACTION} "${INFILE}"
elif [ ${ENV} = 'Mono' ]
then
	[ `echo $ACTION | wc -w` = 1 -o $MODULE = 'lex' -o $MODULE = 'type' ] && mono "${GRC}" ${MODULE} ${ACTION} "${INFILE}"
fi
