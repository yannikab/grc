#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

test `find "$1" -maxdepth 1 -type f -name '*.exe' | wc -l` -eq 0 && exit 1

[ ! -x "${GRC}" ] && ("${DIR}"/build.sh; echo)

if [ ${ENV} = 'Mono' ]
then
	cp "${DIR}"/../"${ENV}"Grc/GrcIO/bin/${CONF}/GrcIO.dll "$1"
fi

pushd "$1" >/dev/null
for f in *.exe; do "${DIR}"/execil.sh "$f"; done
popd >/dev/null

if [ ${ENV} = 'Mono' ]
then
	rm "$1"/GrcIO.dll
fi
