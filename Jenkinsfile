pipeline {
  agent any
  stages {
    stage('Restore and Build') {
      steps {
        sh 'bash ./jenkins/scripts/build.sh'
      }
    }
    stage('Test') {
      steps {
        sh 'bash ./jenkins/scripts/test.sh'
      }
    }
    stage('Publish') {
      steps {
        sh 'bash ./jenkins/scripts/publish.sh'
      }
    }
    stage('Prepare Images') {
      steps {
        sh 'bash ./jenkins/scripts/prepare-images.sh'
      }
    }
    stage('Push Images to Hub and Clean') {
      steps {
        sh '''bash ./jenkins/scripts/push-images.sh

'''
        sh 'bash ./jenkins/scripts/cleanup-images.sh'
      }
    }
    stage('Run Container') {
      steps {
        sh 'bash ./jenkins/scripts/run-container.sh'
        input(message: 'Please connect the Host Url at the Port 9090 for REST Services Access. Are you able to access?', ok: 'Yes, I am able to access the service ... Continue to Next')
        sh 'bash ./jenkins/scripts/cleanup-containers.sh'
      }
    }
  }
  environment {
    CONTAINER_PORT = '9090'
    HOST_PORT = '9090'
    DOCKER_HUB_USER = 'iomega'
    HOME = '.'
    DOCKER_HUB_PASSWORD = 'Prestige'
    DB_CONN_STRING = 'ZGF0YSBzb3VyY2U9aW9tZWdhc3Fsc2VydmVydjIuZGF0YWJhc2Uud2luZG93cy5uZXQ7dXNlciBpZD1pb21lZ2FhZG1pbjtwYXNzd29yZD1QcmVzdGlnZTEyMztpbml0aWFsIGNhdGFsb2c9aW9tZWdhc3FsZGF0YWJhc2V2Mjs='
    CONTAINER_NAME = 'restservices'
  }
}