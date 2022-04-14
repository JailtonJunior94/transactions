using Microsoft.AspNetCore.Mvc;
using Transactions.Core.Domain.Dtos;
using Transactions.Core.Domain.Interfaces.Services;

namespace Transactions.API.Controllers
{
    [Route("api/v1/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionsController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return await _service.GetTransactionAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TransactionRequest request)
        {
            return await _service.CreateTransactionAsync(request);
        }
    }
}
