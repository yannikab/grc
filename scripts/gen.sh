#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

(
cd ${DIR}/../src/main/java;
rm -r k31/grc/cst/{node,lexer,parser,analysis} 2>/dev/null;
sablecc grace.grammar
)
