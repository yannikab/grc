#!/bin/bash

if [ $# -ne 1 ]; then exit 1; fi

INFILE="`echo $1 | sed s://*:/:g`"

if ! echo ${INFILE} | grep -q '.*\.exe$'; then exit 1; fi

OUTFILE=`echo ${INFILE} | sed s:exe\$:il:`

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

[ ! -x "${GRC}" ] && ("${DIR}"/build.sh; echo)

echo "${INFILE} -> ${OUTFILE}"

if [ ${ENV} = 'DotNet' ]
then
	${DIR}/../tools/ildasm.exe /text ${INFILE} | grep -v 'IL_[0-9,a-f]*:  nop' >${OUTFILE}

elif [ ${ENV} = 'Mono' ]
then
	monodis ${INFILE} | grep -v 'IL_[0-9,a-f]*:  nop' >${OUTFILE}
fi
