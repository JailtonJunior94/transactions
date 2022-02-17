namespace Transactions.Core.Domain.Dtos
{
    public class KafkaMessageDto
    {
        public TransactionMessageDto Before { get; set; }
        public TransactionMessageDto After { get; set; }
        public string Op { get; set; }
        public long Ts_ms { get; set; }
        public object Transaction { get; set; }
    }
}
