#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

(cd ${DIR}/../..; for d in code/*; do echo $d; ./scripts/fexec.sh $d; done)
