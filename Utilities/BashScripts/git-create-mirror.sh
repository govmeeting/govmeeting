#!/bin/sh

# This script is from: https://www.edwardthomson.com/blog/mirroring_git_repositories.html
# It makes a mirror of a Github repo and then pushs the mirror to a backup repo on Github.
#
# When it creates a mirror of a repo, it ignores the read-only references that were added by Github.
# This avoids the problem that occurs when we try to push a mirror of a repo back to Github.
# Github would throw an error, if we try to push back these read-only references.
#
# LATER NOTE: Those read-only references likely include the PRs that we want to preserve when
#    useing BFG. The PRs contain a lot of documentation on code changes.
#
# This script pulls just the references that we care about: 
#    the branches (refs/heads), tags (refs/tags) and notes (refs/notes).
# By selecting only these sets of references, we don't clone the private, read-only references.

set -eufo pipefail

# if [ "$#" -ne 2 ]; then
#     echo "usage: $0 source_repo_url target_repo_url" >&2
#     exit 1
# fi

# SOURCE_URL="$1"
SOURCE_URL="https://github.com/govmeeting/govmeeting.git"

# TARGET_URL="$2"
TARGET_URL="https://github.com/johnpankowicz/govmeeting-mirror-2022-7-2.git"

# WORKDIR="$(mktemp -d)"
WORKDIR="$(mktemp -d --tmpdir=/c/GOVMEETING/_SOURCECODE_MIRROR_NO_PRIVATE_REFS)"

echo "Cloning from ${SOURCE_URL} into ${WORKDIR}..."
# exit

git init --bare "${WORKDIR}"
cd "${WORKDIR}"

git config remote.origin.url "${SOURCE_URL}"
git config --add remote.origin.fetch '+refs/heads/*:refs/heads/*'
git config --add remote.origin.fetch '+refs/tags/*:refs/tags/*'
git config --add remote.origin.fetch '+refs/notes/*:refs/notes/*'
git config remote.origin.mirror true

# Note that we will fetch refs/heads/*, refs/tags/* & refs/notes/*, but not refs/pull/*
git fetch --all

echo ""
echo "Cloned to ${WORKDIR};" 

# exit here if we just want to create the mirror.
exit

echo "pushing to ${TARGET_URL}"
git push --mirror "${TARGET_URL}"

echo ""
echo "Cleaning up temporary directory ${WORKDIR}..."
rm -rf "${WORKDIR}"

echo "Done."