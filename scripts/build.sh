#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

cd "${DIR}"/../"${ENV}"Grc
"${BUILDTOOL}" /p:Configuration=${CONF} /target:clean
"${BUILDTOOL}" /p:Configuration=${CONF}

if [ ${ENV} = "DotNet" ]
then
    echo; echo "Adding GrcIO.dll to the Global Assembly Cache (GAC)"; echo
	cd "${DIR}"/../"${ENV}"Grc/GrcIO/bin/${CONF}
	gacutil -i GrcIO.dll
fi
