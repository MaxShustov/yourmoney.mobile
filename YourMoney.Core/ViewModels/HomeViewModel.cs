using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase, IViewModel
    {
        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;
        private readonly string _userId;

        private string _currentBalance;
        private List<Transaction> _transactions;

        public HomeViewModel(IUserService userService, ISettingService settingService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;

            _userId = settingService.UserId;

            Initialize();
        }

        public ICommand IncomeCommand => new RelayCommand(Income);

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

        public void BeforeBack()
        {
            Initialize();
        }

        public void OnBack()
        {
        }

        private async void Initialize()
        {
            CurrentBalance = (await _userService.GetCurrentBalance(_userId)).ToString();
            Transactions = (await _userService.GetTransactions(_userId)).OrderByDescending(t => t.Date).ToList();
        }

        private void Income()
        {
            _navigationService.ShowViewModel<AddIncomeTransactionViewModel>();
        }
    }
}