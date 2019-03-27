#!/usr/bin/env sh

set -x 

docker login --username iomega --password Prestige

docker push iomega/cgiprofessionalnetcoreservicesv2

set +x

