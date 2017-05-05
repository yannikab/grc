#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

(
cd ${DIR}/..
xbuild /target:clean
echo;
find ../code -name '*.png' -exec echo '{}' \; | while read f; do echo "Deleting $f"; rm $f; done
)
