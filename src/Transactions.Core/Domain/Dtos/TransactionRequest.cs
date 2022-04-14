namespace Transactions.Core.Domain.Dtos
{
    public class TransactionRequest
    {
        public int CustomerId { get; set; }
        public decimal TransactionValue { get; set; }
        public string TransactionDescription { get; set; }
    }
}
