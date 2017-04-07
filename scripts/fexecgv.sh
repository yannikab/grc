#!/bin/bash

# rm $1/*.png >/dev/null 2>&1
for f in $1/*.grc; do echo $f; ./execgv.sh $f; done
