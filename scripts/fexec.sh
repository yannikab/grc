#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

for f in $1/*.grc; do ${DIR}/exec.sh $f; done
