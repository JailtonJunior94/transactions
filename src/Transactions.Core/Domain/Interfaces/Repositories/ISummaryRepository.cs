using Transactions.Core.Domain.Entities;

namespace Transactions.Core.Domain.Interfaces.Repositories
{
    public interface ISummaryRepository
    {
        Task<Summary> InsertAsync(Summary entity);
        Task<ICollection<Summary>> GetAsync();
    }
}
