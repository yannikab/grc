#!/bin/bash

# modules: graphviz
MODULE="gv"

# actions: cstsimple, cst, ast, astll
ACTION1="ast"
ACTION2="astll"

if [ $# -ne 1 ]; then exit 1; fi

INFILE="`echo $1 | sed s://*:/:g`"

if ! echo ${INFILE} | grep -q '.*\.grc$'; then exit 1; fi

OUTFILE1=`echo ${INFILE} | sed s:grc\$:${MODULE}.${ACTION1}.png:`
OUTFILE2=`echo ${INFILE} | sed s:grc\$:${MODULE}.${ACTION2}.png:`

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

[ ! -x "${GRC}" ] && ("${DIR}"/build.sh; echo)

echo "${INFILE} ->" 
[ `echo $ACTION1 | wc -w` = 1 -o $MODULE = 'lex' -o $MODULE = 'type' ] && echo ${OUTFILE1}
[ `echo $ACTION2 | wc -w` = 1 ] && echo ${OUTFILE2}
echo

if [ ${ENV} = 'DotNet' ]
then
	[ `echo $ACTION1 | wc -w` = 1 -o $MODULE = 'lex' -o $MODULE = 'type' ] && "${GRC}" ${MODULE} ${ACTION1} "${INFILE}" | cat | dot -Tpng >"${OUTFILE1}"
	[ `echo $ACTION2 | wc -w` = 1 ] && "${GRC}" ${MODULE} ${ACTION2} "${INFILE}" | cat | dot -Tpng >"${OUTFILE2}"
elif [ ${ENV} = 'Mono' ]
then
	[ `echo $ACTION1 | wc -w` = 1 -o $MODULE = 'lex' -o $MODULE = 'type' ] && mono "${GRC}" ${MODULE} ${ACTION1} "${INFILE}" | cat | dot -Tpng >"${OUTFILE1}"
	[ `echo $ACTION2 | wc -w` = 1 ] && mono "${GRC}" ${MODULE} ${ACTION2} "${INFILE}" | cat | dot -Tpng >"${OUTFILE2}"
fi
