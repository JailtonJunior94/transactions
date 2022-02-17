using Transactions.Core.Domain.Dtos;

namespace Transactions.Core.Domain.Interfaces.Repositories
{
    public interface ISummarySQLRepository
    {
        Task<SummaryQueryDto> GetSummaryByIdAndCustomerIdAsync(int transactionId, int customerId);
    }
}
