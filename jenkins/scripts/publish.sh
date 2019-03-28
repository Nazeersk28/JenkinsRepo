#!/usr/bin/env sh

set -x

dotnet publish CRMSystemCoreWebv2 --configuration Release --output outputs

echo "Publishing Completed Successfully ... for Build Id ${BUILD_ID}"

set +x

