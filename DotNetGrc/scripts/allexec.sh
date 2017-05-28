#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source ${DIR}/grc.cfg

(cd ${DIR}/../..; find code -type d -print | sort | while read d; do ./${ENV}Grc/scripts/fexec.sh $d; done)
