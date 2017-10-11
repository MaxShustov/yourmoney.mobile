using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Implementation
{
    public class TransactionApiClient : ITransactionApiClient
    {
        private const string TransactionUrl = "api/transactions";
        private const string TotalSumUrl = "api/transactions/summary";

        private readonly IApiContext _apiContext;

        public TransactionApiClient(IApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task AddTransaction(Transaction transaction)
        {
            return _apiContext.Post(TransactionUrl, transaction);
        }

        public Task<IEnumerable<Transaction>> GetTransactions()
        {
            return _apiContext.Get<IEnumerable<Transaction>>(TransactionUrl);
        }

        public async Task<decimal> GetTotalSum()
        {
            var model = await _apiContext.Get<TotalSumModel>(TotalSumUrl);

            return model.TotalSum;
        }
    }
}