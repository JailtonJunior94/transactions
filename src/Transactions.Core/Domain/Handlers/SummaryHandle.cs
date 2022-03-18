using Microsoft.Extensions.Logging;
using Transactions.Core.Domain.Dtos;
using Transactions.Core.Domain.Entities;
using Transactions.Core.Domain.Interfaces.Handlers;
using Transactions.Core.Domain.Interfaces.Repositories;

namespace Transactions.Core.Domain.Handlers
{
    public class SummaryHandle : ISummaryHandle
    {
        private readonly ILogger<SummaryHandle> _logger;
        private readonly ISummaryRepository _summaryRepository;
        private readonly ISummarySQLRepository _summarySQLRepository;

        public SummaryHandle(ILogger<SummaryHandle> logger,
                             ISummaryRepository summaryRepository,
                             ISummarySQLRepository summarySQLRepository)
        {
            _logger = logger;
            _summaryRepository = summaryRepository;
            _summarySQLRepository = summarySQLRepository;
        }

        public async Task HandleAsync(int transactionId, int customerId)
        {
            SummaryQueryDto query = await _summarySQLRepository.GetSummaryByIdAndCustomerIdAsync(transactionId, customerId);
            if (query is null)
            {
                _logger.LogWarning("[Não foi encontrado nenhum extrato na base de dados SQL Server]");
                return;
            }

            Summary newSummary = new(query.CustomerName, query.CustomerDocument, query.TransactionDescription, query.TransactionValue, query.TransactionDate);
            await _summaryRepository.InsertAsync(newSummary);
            _logger.LogInformation("[Adicionado informações do extrato na base de dados MongoDB]");
        }
    }
}
