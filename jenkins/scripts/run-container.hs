#!/usr/bin/env sh

set -x

docker run -d -t -p ${HOST_PORT}:${CONTAINER_PORT} --name ${CONTAINER_NAME} -e ASPNETCORE_URLS=http://*:${CONTAINER_PORT} -e CRMSystemDBConnectionString=${DB_CONN_STRING} ${DOCKER_HUB_USER}/cgiprofessionalnetcoreservicesjenkins:latest

set +x
