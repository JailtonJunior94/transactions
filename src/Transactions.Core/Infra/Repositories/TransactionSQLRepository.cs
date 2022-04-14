using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Transactions.Core.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Transactions.Core.Domain.Interfaces.Repositories;

namespace Transactions.Core.Infra.Repositories
{
    public class TransactionSQLRepository : ITransactionSQLRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TransactionSQLRepository> _logger;
        private static readonly string _prefix = $"{nameof(TransactionSQLRepository)}";

        public TransactionSQLRepository(IConfiguration configuration,
                                        ILogger<TransactionSQLRepository> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<bool> InsertTransactionAsync(Transaction transaction)
        {
            _logger.LogInformation($"[{_prefix}] [{nameof(InsertTransactionAsync)}] [CustomerID] [{transaction.CustomerId}]");
            try
            {
                const string sql = @"INSERT INTO
                                      [Transaction]
                                    VALUES
                                      (
                                        @customerId,
                                        @transactionValue,
                                        @transactionDate,
                                        @transactionDescription
                                      );";

                using IDbConnection connection = new SqlConnection(_configuration["ConnectionsString:SqlServer"]);
                int rows = await connection.ExecuteAsync(sql: sql, param: new
                {
                    transaction.CustomerId,
                    transaction.TransactionValue,
                    transaction.TransactionDate,
                    transaction.TransactionDescription

                }, commandTimeout: 300);

                _logger.LogInformation($"[{_prefix}] [{nameof(InsertTransactionAsync)}] [Success?] [{(rows > 0 ? "YES" : "NO")}]");
                return rows > 0;
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{_prefix}] [{nameof(InsertTransactionAsync)}] [{exception?.Message}]");
                return false;
            }
        }
    }
}
