using MongoDB.Driver;
using Transactions.Core.Domain.Entities;
using Transactions.Core.Domain.Interfaces.Contexts;
using Transactions.Core.Domain.Interfaces.Repositories;

namespace Transactions.Core.Infra.Repositories
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly IMongoCollection<Summary> _collection;

        public SummaryRepository(IMongoDbContext context)
        {
            _collection = context.GetCollection<Summary>("summaries");
        }

        public async Task<Summary> InsertAsync(Summary entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }
    }
}
