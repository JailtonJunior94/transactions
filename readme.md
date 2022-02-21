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