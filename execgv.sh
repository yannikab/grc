#!/bin/bash

if [ $# -ne 1 ]; then exit; fi

if ! echo $1 | grep -q '.*\.grc$'; then exit; fi

java -jar target/grc-0.0.1-SNAPSHOT.jar $1 | dot -Tpng >`echo $1 | sed s/grc/png/`
