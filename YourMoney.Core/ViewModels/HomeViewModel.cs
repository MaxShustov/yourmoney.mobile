using System.Collections.Generic;
using GalaSoft.MvvmLight;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly string _userId;

        private string _currentBalance;
        private List<Transaction> _transactions;

        public HomeViewModel(IUserService userService, ISettingService settingService)
        {
            _userService = userService;

            _userId = settingService.UserId;

            Initialize();
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

        public List<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
            set
            {
                Set(() => Transactions, ref _transactions, value);
            }
        }

        private async void Initialize()
        {
            CurrentBalance = (await _userService.GetCurrentBalance(_userId)).ToString();
            Transactions = await _userService.GetTransactions(_userId);
        }
    }
}