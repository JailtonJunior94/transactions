namespace Transactions.Core.Domain.Entities
{
    public class Summary
    {
        public Summary() { }
        public Summary(string customerName, string customerDocument, string transactionDescription, decimal transactionValue, DateTime transactionDate)
        {
            CustomerName = customerName;
            CustomerDocument = customerDocument;
            TransactionDescription = transactionDescription;
            TransactionValue = transactionValue;
            TransactionDate = transactionDate;
        }

        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerDocument { get; set; }
        public string TransactionDescription { get; set; }
        public decimal TransactionValue { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
