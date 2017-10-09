using System;
using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionApiClient _transactionApiClient;
        private readonly ISettingService _settingService;

        public TransactionService(ITransactionApiClient transactionApiClient, ISettingService settingService)
        {
            _transactionApiClient = transactionApiClient;
            _settingService = settingService;
        }

        public Task AddTransaction(Transaction transaction)
        {
            transaction.Date = DateTime.Now;

            return _transactionApiClient.AddTransaction(transaction);
        }
    }
}
