#!/bin/bash

# BUILDTOOL=xbuild
BUILDTOOL=MSBuild.exe

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

(
cd ${DIR}/..
${BUILDTOOL} /target:clean
echo;
find ../code -name '*.png' -exec echo '{}' \; | while read f; do echo "Deleting $f"; rm $f; done
)
