
#!/usr/bin/env sh

set -x

dotnet test

echo "Test Completed Successfully ... for Build Id ${BUILD_ID}"

set +x
