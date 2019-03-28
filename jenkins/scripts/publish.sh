#!/usr/bin/env sh

set -x

dotnet publish CRMSystemCoreWeb --configuration Release --output outputs

echo "Publishing Completed Successfully ... for Build Id ${BUILD_ID}"

set +x

