#!/bin/bash

cd ..
mvn -Dmaven.test.skip=true $* package
cd scripts
