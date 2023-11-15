# Deployment - управляет состоянием развертывания подов

Манифест такой же, как у ReplicaSet. Кроме kind

<!-- ---
apiVersion: apps/v1
kind: Deployment
metadata:
  name: my-deployment
spec:
  replicas: 2
  selector:
    matchLabels:
      app: my-app
  template:
    metadata:
      labels:
        app: my-app
    spec:
      containers:
      - image: nginx:1.12
        name: nginx
        ports:
        - containerPort: 80 -->

<!-- Развернем наш deployment -->

kubectl apply deploy my-deployment

<!-- Проверим настройки deploy -->

kubectl describe deploy my-deployment

<!-- Изменение настроек -->

kubectl edit deploy my-deployment

<!-- Можем изменить на лету версию -->

<!-- Проверка истории -->

kubectl rollout history my-deployment
