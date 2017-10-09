using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Implementation
{
    public class UserApiClient : IUserApiClient
    {
        private const string LoginUrl = "api/login";
        private const string RegisterUrl = "api/users/";
        private const string SummaryUrl = "api/users/{0}/summary";
        private const string TransactionsForUserUrl = "api/users/{0}/transactions";

        private readonly IApiContext _apiContext;

        public UserApiClient(IApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task<string> Login(LoginModel loginModel)
        {
            return _apiContext.Login(LoginUrl, loginModel);
        }

        public Task Register(RegisterModel registerModel)
        {
            return _apiContext.Post(RegisterUrl, registerModel);
        }

        public Task<CurrentBalanceResponseModel> GetCurrentBalance(string userId)
        {
            return _apiContext.Get<CurrentBalanceResponseModel>(string.Format(SummaryUrl, userId));
        }

        public Task<List<Transaction>> GetTransactionForUser(string userId)
        {
            return _apiContext.Get<List<Transaction>>(string.Format(TransactionsForUserUrl, userId));
        }
    }
}