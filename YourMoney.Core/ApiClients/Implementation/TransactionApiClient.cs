using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Implementation
{
    public class TransactionApiClient : ITransactionApiClient
    {
        private const string TransactionUrl = "api/transactions";

        private readonly IApiContext _apiContext;

        public TransactionApiClient(IApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task AddTransaction(Transaction transaction)
        {
            return _apiContext.Post(TransactionUrl, transaction);
        }
    }
}