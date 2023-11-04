pipeline {
  agent any
  stages {
    stage('Start deploy') {
      steps {
        echo 'Deploy start'
      }
    }

    stage('Build docker ') {
      steps {
        sh 'docker build -t restaurant-image -f restaurant/Dockerfile .'
      }
    }

    stage('Delete existing container') {
      steps {
        sh '''existingContainerId=$(docker ps -aqf name=core-restaurant)

if [ -n "$existingContainerId" ]; then
    docker stop $existingContainerId
    docker rm $existingContainerId
 '''
      }
    }

    stage('Create new container') {
      steps {
        sh 'docker run -d --name core-restaurant restaurant-image:latest'
      }
    }

  }
}