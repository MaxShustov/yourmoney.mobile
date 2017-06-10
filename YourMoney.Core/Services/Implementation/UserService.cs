using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.ViewModels;

namespace YourMoney.Core.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IViewModelNavigationService _navigationService;

        public UserService(IUserApiClient userApiClient, IViewModelNavigationService navigationService)
        {
            _userApiClient = userApiClient;
            _navigationService = navigationService;
        }

        public async Task Login(string userName, string password)
        {
            var loginModel = new LoginModel
            {
                UserName = userName,
                Password = password
            };

            var userId = await _userApiClient.Login(loginModel);

            _navigationService.ShowViewModel<RegisterViewModel>();
            //TODO add saving to setting
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
    }
}