#!/bin/bash

cd src/main/java;
rm -r k31/grc/{node,lexer,parser,analysis} 2>/dev/null;
sablecc grace.grammar # && (cd ../../.. ; mvn clean package)
cd ../../..