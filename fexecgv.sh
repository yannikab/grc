#!/bin/bash

for f in $1/*.grc; do ./exec.sh $f | dot -Tpng >`echo $f | sed s/grc/png/`; done
