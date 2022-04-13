# Transações POC

## Desenho da solução

## Como configurar o CDC

## Como configurar o Debezium Connect
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
      "snapshot.mode":"initial_schema_only",
      "database.history":"io.debezium.relational.history.MemoryDatabaseHistory"
   }
}
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
  