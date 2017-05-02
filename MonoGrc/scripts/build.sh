#!/bin/bash

# BUILDTOOL=xbuild
BUILDTOOL=MSBuild.exe

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

cd ${DIR}/..
${BUILDTOOL} /target:clean
${BUILDTOOL}
