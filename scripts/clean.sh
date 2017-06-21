#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source "${DIR}"/grc.cfg

(
cd "${DIR}"/../"${ENV}"Grc
"${BUILDTOOL}" /target:clean /p:Configuration=Debug
"${BUILDTOOL}" /target:clean /p:Configuration=Release
echo;
find ../code \( -type f -name '*.png' -o -name '*.txt' -o -name '*.exe' -o -name '*.pdb' -o -name '*.il' -o -name '*.tmp' -o -name '*.dll' \) -exec echo '{}' \; | while read f; do echo "Deleting $f"; rm "$f"; done
)
