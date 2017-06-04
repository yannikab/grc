#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

cd "${DIR}"/../"${ENV}"Grc
"${BUILDTOOL}" /p:Configuration=${CONF} /target:clean
"${BUILDTOOL}" /p:Configuration=${CONF}
