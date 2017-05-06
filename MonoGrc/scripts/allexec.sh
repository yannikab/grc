#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

GRC=${DIR}/../Grc/bin/Debug/Grc.exe

test ! -x ${GRC} && exit

(cd ${DIR}/../..; for d in code/*/*; do echo $d; ./MonoGrc/scripts/fexec.sh $d; done)
