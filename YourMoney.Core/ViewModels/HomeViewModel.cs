using System;
using GalaSoft.MvvmLight;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private IUserService _userService;
        private Guid _userId;

        private string _currentBalance;

        public HomeViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public string CurrentBalance
        {
            get
            {
                return _currentBalance;
            }
            set
            {
                Set(() => CurrentBalance, ref _currentBalance, value);
            }
        }

        private async void Initialize()
        {
            CurrentBalance = (await _userService.GetCurrentBalance(_userId)).ToString();
        }
    }
}