#!/usr/bin/env sh

set -x

docker build -t ${DOCKER_HUB_USER}/cgiprofessionalnetcoreservicesjenkins:${BUILD_ID} .

docker tag  ${DOCKER_HUB_USER}/cgiprofessionalnetcoreservicesjenkins:${BUILD_ID} ${DOCKER_HUB_USER}/cgiprofessionalnetcoreservicesjenkins:latest

set +x

