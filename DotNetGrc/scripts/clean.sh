#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source ${DIR}/tool.cfg

(
cd ${DIR}/..
${BUILDTOOL} /target:clean
echo;
find ../code \( -name '*.txt' -o -name '*.png' \) -exec echo '{}' \; | while read f; do echo "Deleting $f"; rm $f; done
)
