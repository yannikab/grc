#!/bin/bash

for f in $1/*.grc; do echo $f; ./exec.sh $f; done
