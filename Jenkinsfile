//Declarative Pipeline
pipeline  {
  agent any

  stages {
    stage('Docker Image Build') {
      steps {
        dir('QuantityMeasurement') {
          sh "docker build -f Dockerfile -t 01vishal/quantitymeasurementbackend:dev ../ "
          echo 'docker Image Build'
        }
      }
    }
    stage('Docker Image push') {
      steps {
        withCredentials([string(credentialsId: 'dockerpassword', variable: 'Dockerpassword')]) {
          sh "docker login -u 01vishal -p ${Dockerpassword}"
        }
        sh 'docker push 01vishal/quantitymeasurementbackend:dev'
        sh 'docker image rm -f  01vishal/quantitymeasurementbackend:dev'
        echo 'Docker Image Pushed from QuantityMeasurement'
      }
    }
    stage('Docker Image Run') {
      steps {
          sshagent(['devkey']) {
            withCredentials([string(credentialsId: 'DockerRun', variable: 'DockerRun')]) {
               withCredentials([string(credentialsId: 'DevServer', variable: 'DevServer')]) {
                  sh "ssh -o StrictHostKeyChecking=no -T '${DevServer}' docker stop quantitymeasurementbackend"
                  sh "ssh -o StrictHostKeyChecking=no -T '${DevServer}' docker rm -f quantitymeasurementbackend"
                  sh "ssh -o StrictHostKeyChecking=no -T '${DevServer}' docker image rm -f  01vishal/quantitymeasurementbackend:dev"
                  sh "ssh -o StrictHostKeyChecking=no -T '${DevServer}' docker run -d --name quantitymeasurementbackend -e '${DockerRun}' -p 8080:80 -t 01vishal/quantitymeasurementbackend:dev "
                    }
               }
          }
          echo 'Docker Image Run'
        }
      }
  }
}
