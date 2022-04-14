# Transações POC

## Desenho da solução

## Como configurar o CDC

## Como configurar o Debezium Connect
- Collection Postman (Debezium Connect)
  ```
  https://www.getpostman.com/collections/5b52d47ffcc20aef0858
  ```
- Cadastrando conector para ouvir eventos do CDC
  ```
  {
    "name":"sql-server-connection",
    "config":{
        "connector.class":"io.debezium.connector.sqlserver.SqlServerConnector",
        "database.hostname":"mssql",
        "database.port ":"1433",
        "database.user":"sa",
        "database.password":"@docker@2021",
        "database.dbname":"Transaction",
        "database.server.name":"transacion_server",
        "table.whitelist":"dbo.Transaction",
        "database.history":"io.debezium.relational.history.MemoryDatabaseHistory"
    }
  }
  ```
## Como utilizar docker

- Build da imagem 
  ```
  docker image build -t jailtonjunior/transactions_worker:v1 -f src/Transactions.Worker/Dockerfile .
  docker image build -t jailtonjunior/transactions_api:v1 -f src/Transactions.API/Dockerfile .
  ```
- Logando no docker
  ```
  docker login
  ```
- Push da imagem criada
  ```
  docker push jailtonjunior/transactions_worker:v1
  docker push jailtonjunior/transactions_api:v1
  ```

## Como utilizar em ambiente local

## Como utilizar no K8S
- Verificando o contexto (cluster configurado)
  ```
  kubectl config get-contexts
  ```
- Alterando o contexto (cluster). Se necessário.
  ```
  kubectl config use-context (nome do contexto)
  ```
- Criando namespace 
  ```
  kubectl apply -f .\.k8s\namespaces\ -R
  ```
- Criando deployments 
  ```
  kubectl apply -f .\.k8s\deployments\ -R -n transactions
  ```
- Criando services 
  ```
  kubectl apply -f .\.k8s\services\ -R -n transactions
  ```
  
## Utilizando AKS 
- Autenticação no novo cluster
  ```
  az aks get-credentials --resource-group transactions-rg --name transactions-aks
  ```