#!/usr/bin/env sh

set -x 

dotnet restore
dotnet build

set +x
