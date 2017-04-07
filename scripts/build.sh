#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

cd ${DIR}/..
mvn clean
./scripts/gen.sh
./scripts/compile.sh
