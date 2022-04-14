using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Transactions.Core.Domain.Dtos;
using Transactions.Core.Domain.Entities;
using Transactions.Core.Domain.Interfaces.Services;
using Transactions.Core.Domain.Interfaces.Repositories;

namespace Transactions.Core.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ILogger<TransactionService> _logger;
        private readonly ISummaryRepository _repositoryMongoSummary;
        private readonly ITransactionSQLRepository _repositorySQLTransaction;

        public TransactionService(ILogger<TransactionService> logger,
                                  ISummaryRepository repositoryMongoSummary,
                                  ITransactionSQLRepository repositorySQLTransaction)
        {
            _logger = logger;
            _repositoryMongoSummary = repositoryMongoSummary;
            _repositorySQLTransaction = repositorySQLTransaction;
        }

        public async Task<ObjectResult> CreateTransactionAsync(TransactionRequest request)
        {
            Transaction transaction = new(request.CustomerId, request.TransactionValue, request.TransactionDescription);
            bool sucesso = await _repositorySQLTransaction.InsertTransactionAsync(transaction);

            if (!sucesso) return new ObjectResult("") { StatusCode = StatusCodes.Status400BadRequest };

            return new ObjectResult("") { StatusCode = StatusCodes.Status201Created };
        }

        public async Task<ObjectResult> GetTransactionAsync()
        {
            ICollection<Summary> summaries = await _repositoryMongoSummary.GetAsync();
            if (summaries.Count <= 0) return new ObjectResult("") { StatusCode = StatusCodes.Status404NotFound };

            return new ObjectResult(summaries) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
