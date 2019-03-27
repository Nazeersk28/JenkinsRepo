pipeline {
  agent any
  stages {
    stage('Initialize') {
      steps {
        sh 'bash ./jenkins/scripts/init.sh'
      }
    }
    stage('Restore and Build') {
      steps {
        sh 'bash ./jenkins/scripts/restore-build.sh'
        echo 'Restore and Build Completed Successfully'
      }
    }
  }
  environment {
    CONTAINER_NAME = 'restservicesv2'
    HOME = '.'
  }
}