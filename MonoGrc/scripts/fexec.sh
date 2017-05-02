#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

GRC=${DIR}/../Grc/bin/Debug/Grc.exe

test ! -x ${GRC} && exit

for f in $1/*.grc; do ${DIR}/exec.sh $f; done
