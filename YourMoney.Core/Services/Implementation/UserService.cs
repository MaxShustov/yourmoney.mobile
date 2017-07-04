using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserApiClient _userApiClient;
        private readonly ISettingService _settingService;

        public UserService(IUserApiClient userApiClient, ISettingService settingService)
        {
            _userApiClient = userApiClient;
            _settingService = settingService;
        }

        public async Task Login(string userName, string password)
        {
            var loginModel = new LoginModel
            {
                UserName = userName,
                Password = password
            };

            var oldUserId = _settingService.UserId;
            var userId = await _userApiClient.Login(loginModel);

            _settingService.UserId = userId;
        }

        public async Task Register(string userName, string password, string email)
        {
            var registerModel = new RegisterModel
            {
                UserName = userName,
                Password = password,
                Email = email
            };

            await _userApiClient.Register(registerModel);
        }

        public async Task<decimal> GetCurrentBalance(string userId)
        {
            var currentBalance = await _userApiClient.GetCurrentBalance(userId);

            return currentBalance.CurrentBalance;
        }

        public Task<List<Transaction>> GetTransactions(string userId)
        {
            return _userApiClient.GetTransactionForUser(userId);
        }
    }
}