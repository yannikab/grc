#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

test `find "$1" -maxdepth 1 -type f -name '*.grc' | wc -l` -eq 0 && exit 1

[ ! -x "${GRC}" ] && ("${DIR}"/build.sh; echo)

pushd "$1" >/dev/null
for f in *.grc; do "${DIR}"/exectxt.sh "$f"; done
popd >/dev/null
