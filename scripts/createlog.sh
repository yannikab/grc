#! /bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

(cd ${DIR}/..; git log --date=iso --pretty=format:"%h%x09%an%x09%ad%x09%s" >ChangeLog)
