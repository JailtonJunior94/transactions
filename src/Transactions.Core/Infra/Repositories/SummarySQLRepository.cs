using Dapper;
using System.Data;
using System.Data.SqlClient;
using Transactions.Core.Domain.Dtos;
using Microsoft.Extensions.Configuration;
using Transactions.Core.Domain.Interfaces.Repositories;

namespace Transactions.Core.Infra.Repositories
{
    public class SummarySQLRepository : ISummarySQLRepository
    {
        private readonly IConfiguration _configuration;

        public SummarySQLRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SummaryQueryDto> GetSummaryByIdAndCustomerIdAsync(int transactionId, int customerId)
        {
            const string sql = @"SELECT
                                  C.[Name] CustomerName,
                                  C.[Document] CustomerDocument,
                                  T.[TransactionDescription],
                                  T.[TransactionValue],
                                  T.[TransactionDate]
                                FROM
                                  dbo.[Transaction] (NOLOCK) T
                                  INNER JOIN dbo.[Customers] (NOLOCK) C ON T.CustomerId = C.Id
                                WHERE
                                  T.Id = @transactionId
                                  AND T.CustomerId = @customerId";

            using IDbConnection connection = new SqlConnection(_configuration["ConnectionsString:SqlServer"]); ;
            SummaryQueryDto summary = await connection.QueryFirstOrDefaultAsync<SummaryQueryDto>(sql: sql, param: new { transactionId, customerId });

            return summary;
        }
    }
}
