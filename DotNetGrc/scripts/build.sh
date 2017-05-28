#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

source ${DIR}/tool.cfg

cd ${DIR}/..
${BUILDTOOL} /target:clean
${BUILDTOOL}
