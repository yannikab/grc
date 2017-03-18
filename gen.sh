#!/bin/bash

rm -r src/main/java/k31/grc/{node,lexer,parser,analysis}; (cd src/main/java/;  sablecc grace.grammar)
