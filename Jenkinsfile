pipeline {
  agent any
  stages {
    stage('Prepare Images') {
      steps {
        sh 'bash ./jenkins/scripts/prepare-image.sh'
      }
    }
    stage('Clear Prune Images') {
      steps {
        sh 'bash ./jenkins/scripts/cleanup-images.sh'
      }
    }
  }
  environment {
    HOME = '.'
    DOCKER_HUB_USER = 'iomega'
    DOCKER_HUB_PASSWORD = 'Prestige'
    CONTAINER_PORT = '9090'
    CONNECTION_STRING = 'ZGF0YSBzb3VyY2U9aW9tZWdhc3Fsc2VydmVydjIuZGF0YWJhc2Uud2luZG93cy5uZXQ7dXNlciBpZD1pb21lZ2FhZG1pbjtwYXNzd29yZD1QcmVzdGlnZTEyMztpbml0aWFsIGNhdGFsb2c9aW9tZWdhc3FsZGF0YWJhc2V2Mjs='
    CLUSTER_NAME = 'iomega'
    CONTAINER_NAME = 'TestServices'
    HOST_PORT = '9090'
  }
}