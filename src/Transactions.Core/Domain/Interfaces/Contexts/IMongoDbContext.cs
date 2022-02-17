using MongoDB.Driver;

namespace Transactions.Core.Domain.Interfaces.Contexts
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);
    }
}
