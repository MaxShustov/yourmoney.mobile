using System;
using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Implementation
{
    public class UserApiClient : IUserApiClient
    {
        private const string LoginUrl = "api/users/login";
        private const string RegisterUrl = "api/users/";

        private readonly IApiContext _apiContext;

        public UserApiClient(IApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task<Guid> Login(LoginModel loginModel)
        {
            return _apiContext.Login(LoginUrl, loginModel);
        }

        public Task Register(RegisterModel registerModel)
        {
            return _apiContext.Post(RegisterUrl, registerModel);
        }
    }
}