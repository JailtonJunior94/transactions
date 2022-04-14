using Transactions.Core.Shared.Extensions;

namespace Transactions.Core.Domain.Entities
{
    public class Transaction
    {
        public Transaction() { }
        public Transaction(int customerId, decimal transactionValue, string transactionDescription)
        {
            CustomerId = customerId;
            TransactionValue = transactionValue;
            TransactionDate = DateTime.Now.GetBrazilianTime();
            TransactionDescription = transactionDescription;
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TransactionValue { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
    }
}
