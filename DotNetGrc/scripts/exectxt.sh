#!/bin/bash

# modules: lex, parse, type, code
MODULE="code"

# actions:
# lex -> ""
# parse -> cst, ast
# type -> ""
# code -> src, tac
ACTION1="src"
ACTION2="tac"

if [ $# -ne 1 ]; then exit 1; fi

INFILE="`echo $1 | sed s://*:/:g`"

if ! echo ${INFILE} | grep -q '.*\.grc$'; then exit 1; fi

OUTFILE1=`echo ${INFILE} | sed s:grc\$:${MODULE}.${ACTION1}.txt:`
OUTFILE2=`echo ${INFILE} | sed s:grc\$:${MODULE}.${ACTION2}.txt:`

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

[ ! -x "${GRC}" ] && ("${DIR}"/build.sh; echo)

echo "${INFILE} ->" 
[ `echo $ACTION1 | wc -w` = 1 -o $MODULE = 'lex' -o $MODULE = 'type' ] && echo ${OUTFILE1}
[ `echo $ACTION2 | wc -w` = 1 ] && echo ${OUTFILE2}
echo

if [ ${ENV} = 'DotNet' ]
then
    [ `echo $ACTION1 | wc -w` = 1 -o $MODULE = 'lex' -o $MODULE = 'type' ] && "${GRC}" ${MODULE} ${ACTION1} "${INFILE}" >"${OUTFILE1}"
    [ `echo $ACTION2 | wc -w` = 1 ] && "${GRC}" ${MODULE} ${ACTION2} "${INFILE}" >"${OUTFILE2}"
elif [ ${ENV} = 'Mono' ]
then
    [ `echo $ACTION1 | wc -w` = 1 -o $MODULE = 'lex' -o $MODULE = 'type' ] && mono "${GRC}" ${MODULE} ${ACTION1} "${INFILE}" >"${OUTFILE1}"
    [ `echo $ACTION2 | wc -w` = 1 ] && mono "${GRC}" ${MODULE} ${ACTION2} "${INFILE}" >"${OUTFILE2}"
fi
