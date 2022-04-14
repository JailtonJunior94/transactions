using Transactions.Core.Domain.Entities;

namespace Transactions.Core.Domain.Interfaces.Repositories
{
    public interface ITransactionSQLRepository
    {
        Task<bool> InsertTransactionAsync(Transaction transaction);
    }
}
