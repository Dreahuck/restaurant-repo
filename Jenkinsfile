pipeline {
  agent any
  stages {
    stage('Start deploy') {
      parallel {
        stage('Start deploy') {
          steps {
            echo 'Deploy start'
          }
        }

        stage('Unit test') {
          steps {
            sh '''dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput="./${workspace}/CoverageResults/cobertura.xml"
'''
            archiveArtifacts './${workspace}/CoverageResults/cobertura.xml'
          }
        }

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

echo $existingContainerId 

if [ -n "$existingContainerId" ]; then
    docker stop $existingContainerId
    docker rm $existingContainerId
fi
'''
      }
    }

    stage('Create new container') {
      steps {
        sh 'docker run -p 5001:5001 -d --name core-restaurant restaurant-image:latest'
      }
    }

  }
}