#!/bin/sh

# Finding a file by its corresponding blob's hash in a git repository?
# https://stackoverflow.com/a/39614949/1978840

obj_name="$1"
shift
git log "$@" --pretty=format:'%T %h %s' \
| while read tree commit subject ; do
    git ls-tree -r "$commit" | while read _ _ sha name; do \
      if [ "$sha" == "$obj_name" ]; then
        echo "$sha\t$name"
        break
      fi
    done
  done