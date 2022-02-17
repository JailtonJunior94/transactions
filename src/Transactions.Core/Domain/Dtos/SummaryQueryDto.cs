namespace Transactions.Core.Domain.Dtos
{
    public class SummaryQueryDto
    {
        public string CustomerName { get; set; }
        public string CustomerDocument { get; set; }
        public string TransactionDescription { get; set; }
        public decimal TransactionValue { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
