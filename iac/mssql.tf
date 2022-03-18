# resource "azurerm_mssql_server" "cdc_mssql_server" {
#   name                         = "cdc-sqlserver"
#   resource_group_name          = azurerm_resource_group.transactions_rg.name
#   location                     = azurerm_resource_group.transactions_rg.location
#   version                      = "12.0"
#   administrator_login          = "cdc_admin"
#   administrator_login_password = "2021@Keycl0@k"
# }

# resource "azurerm_mssql_database" "cdc_mssql_database" {
#   name         = "Transactions"
#   server_id    = azurerm_mssql_server.cdc_mssql_server.id
#   collation    = "SQL_Latin1_General_CP1_CI_AS"
#   license_type = "LicenseIncluded"
#   sku_name     = "Basic"
# }
