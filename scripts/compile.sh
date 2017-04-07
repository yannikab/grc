#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

(cd ${DIR}/..; mvn -Dmaven.compiler.source=1.8 -Dmaven.compiler.target=1.8 -Dmaven.test.skip=true package)
