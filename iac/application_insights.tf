resource "azurerm_application_insights" "application_insights_transactions" {
  name                = "transactions-insights"
  location            = azurerm_resource_group.transactions_rg.location
  resource_group_name = azurerm_resource_group.transactions_rg.name
  application_type    = "web"

  tags = {
    project = "transactions_poc"
  }
}
