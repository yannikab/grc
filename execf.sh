#!/bin/bash

for f in $1/*; do ./exec.sh $f; read; done
