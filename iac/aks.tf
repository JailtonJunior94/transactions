resource "azurerm_kubernetes_cluster" "transactions_aks" {
  name                = "transactions-aks"
  location            = azurerm_resource_group.transactions_rg.location
  resource_group_name = azurerm_resource_group.transactions_rg.name

  dns_prefix = "transactions-aks"
  sku_tier   = "Free"

  default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_B2s"
  }

  identity {
    type = "SystemAssigned"
  }

  tags = {
    project = "transactions_poc"
  }
}

provider "kubernetes" {
  host                   = azurerm_kubernetes_cluster.transactions_aks.kube_config.0.host
  client_certificate     = base64decode(azurerm_kubernetes_cluster.transactions_aks.kube_config.0.client_certificate)
  client_key             = base64decode(azurerm_kubernetes_cluster.transactions_aks.kube_config.0.client_key)
  cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.transactions_aks.kube_config.0.cluster_ca_certificate)
}
