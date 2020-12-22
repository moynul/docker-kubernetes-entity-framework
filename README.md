# docker-kubernetes-entity-framework
docker kubernetes entity framework and .net core c#
====docker command ====
---Create Image-------
docker-compose up
docker-compose -f "docker-compose.yml" up -d
docker images
docker ps
-----
----- Push image to docker local registry-----
docker tag dockerkubernetesexample:latest moynuldocker/dockerkubernetesexample:latest
docker push moynuldocker/dockerkubernetesexample:latest 
docker run -p 8080:80 moynuldocker/dockerkubernetesexample
-----------
 
=======Kubernaties command======
kubectl create -f .\deployment.yaml
kubectl apply -f .\service.yaml
kubectl apply -f .\Ingress.yaml
kubectl get deployments
kubectl get services
kubectl  get pods

