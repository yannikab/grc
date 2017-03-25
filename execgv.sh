#!/bin/bash

java -jar target/grc-0.0.1-SNAPSHOT.jar $1 | dot -Tpng >$1.png
