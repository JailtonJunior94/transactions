namespace Transactions.Core.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TransactionValue { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
    }
}
