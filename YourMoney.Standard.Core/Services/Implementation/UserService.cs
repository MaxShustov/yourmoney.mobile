using System;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Services.Abstract;
using System.Reactive.Linq;
using System.Reactive;
using ReactiveUI;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ISettingService _settingService;
        private readonly IUsersApi _usersApi;

        public UserService(ISettingService settingService, IUsersApi usersApi)
        {
            _settingService = settingService;
            _usersApi = usersApi;
        }

        public IObservable<Unit> Login(string userName, string password)
        {
            var loginRequestModel = new LoginRequestModel(userName, password);

            return _usersApi.Login(loginRequestModel)
                            .ObserveOn(RxApp.TaskpoolScheduler)
                            .Select(m => m.Token)
                            .Do(t => _settingService.Token = t)
                            .Select(u => Unit.Default);
        }

        public IObservable<Unit> Register(string userName, string password, string email)
        {
            var resgisterRequestModel = new RegisterRequestModel(userName, password, email);

            return _usersApi.Register(resgisterRequestModel);
        }
    }
}