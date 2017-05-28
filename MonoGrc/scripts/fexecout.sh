#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source ${DIR}/grc.cfg

test `find $1 -maxdepth 1 -type f -name '*.grc' | wc -l` -eq 0 && exit 1

for f in $1/*.grc; do ${DIR}/execout.sh $f; done
