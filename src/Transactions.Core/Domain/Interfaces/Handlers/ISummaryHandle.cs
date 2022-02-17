﻿using Transactions.Core.Domain.Entities;

namespace Transactions.Core.Domain.Interfaces.Handlers
{
    public interface ISummaryHandle
    {
        Task HandleAsync(int transactionId, int customerId);
    }
}
