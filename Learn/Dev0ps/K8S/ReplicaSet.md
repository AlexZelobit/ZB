# Мы можем запускать несколько реплик одного приложения

<!-- Создадим конфигурацию и запустим ее -->

kubectl apply -f replicaset.yaml

<!-- ---
apiVersion: apps/v1
kind: ReplicaSet
metadata:
  name: my-replicaset
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
