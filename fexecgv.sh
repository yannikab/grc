#!/bin/bash

for f in $1/*.grc; do ./execgv.sh $f; done
