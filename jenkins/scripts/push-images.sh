#!/usr/bin/env sh

set -x

docker login --username ${DOCKER_HUB_USER} --password ${DOCKER_HUB_PASSWORD}

docker push ${DOCKER_HUB_USER}/cgiprofessionalnetcoreservicesjenkins:${BUILD_ID}

docker push ${DOCKER_HUB_USER}/cgiprofessionalnetcoreservicesjenkins:latest

set +x
