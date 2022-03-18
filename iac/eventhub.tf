resource "azurerm_eventhub_namespace" "eventhub_namespace_transactions" {
  name                = "transactions-events"
  location            = azurerm_resource_group.transactions_rg.location
  resource_group_name = azurerm_resource_group.transactions_rg.name
  sku                 = "Standard"
  capacity            = 1

  tags = {
    project = "transactions_poc"
  }
}
