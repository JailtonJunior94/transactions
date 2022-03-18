output "event_hub_connection_string" {
  value = nonsensitive(azurerm_eventhub_namespace.eventhub_namespace_transactions.default_primary_connection_string)
}
