#!/usr/bin/env sh

set -x 

docker run -d -t -p 9090:8080 -e ASPNETCORE_URLS=http://*:8080 -e CRMSystemDBConnectionString=ZGF0YSBzb3VyY2U9aW9tZWdhc3Fsc2VydmVydjIuZGF0YWJhc2Uud2luZG93cy5uZXQ7dXNlciBpZD1pb21lZ2FhZG1pbjtwYXNzd29yZD1QcmVzdGlnZTEyMztpbml0aWFsIGNhdGFsb2c9aW9tZWdhc3FsZGF0YWJhc2V2Mjs= --name restservices iomega/cgiprofessionalnetcoreservicesv2

set +x