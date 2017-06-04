#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

(
cd ${DIR}/..;
mvn clean;
echo;
echo "Removing SableCC generated classes"
rm -r src/main/java/k31/grc/cst/{node,lexer,parser,analysis} 2>/dev/null;
echo;
find code -name '*.png' -exec echo '{}' \; | while read f; do echo "Deleting $f"; rm $f; done
)
