using Microsoft.AspNetCore.Mvc;
using Transactions.Core.Domain.Dtos;

namespace Transactions.Core.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<ObjectResult> GetTransactionAsync();
        Task<ObjectResult> CreateTransactionAsync(TransactionRequest request);
    }
}
