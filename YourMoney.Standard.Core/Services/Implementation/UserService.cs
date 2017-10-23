using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ISettingService _settingService;
        private readonly IUsersApi _usersApi;

        public UserService(ISettingService settingService, HttpClient httpClient)
        {
            _settingService = settingService;
            _usersApi = RestService.For<IUsersApi>(httpClient);
        }

        public async Task Login(string userName, string password)
        {
            var loginRequestModel = new LoginRequestModel(userName, password);

            var loginResponseModel = await _usersApi.Login(loginRequestModel);

            _settingService.Token = loginResponseModel.Token;
        }

        public Task Register(string userName, string password, string email)
        {
            var resgisterRequestModel = new RegisterRequestModel(userName, password, email);

            return _usersApi.Register(resgisterRequestModel);
        }
    }
}