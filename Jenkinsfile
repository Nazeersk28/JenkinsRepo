pipeline {
  agent any
  stages {
    stage('Initialize') {
      steps {
        sh 'bash ./jenkins/scripts/init.sh'
      }
    }
  }
  environment {
    CONTAINER_NAME = 'restservicesv2'
    HOME = '.'
  }
}