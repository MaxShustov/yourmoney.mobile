using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;
        private readonly string _userId;

        private string _currentBalance;
        private ObservableCollection<Transaction> _transactions;

        public HomeViewModel(IUserService userService, ISettingService settingService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;

            _userId = settingService.UserId;

            _transactions = new ObservableCollection<Transaction>();
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

        public ObservableCollection<Transaction> Transactions
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

        public override void Appeared()
        {
            base.Appeared();

            GetData();
        }

        private async void GetData()
        {
            CurrentBalance = (await _userService.GetCurrentBalance(_userId)).ToString();
            Transactions = new ObservableCollection<Transaction>((await _userService.GetTransactions(_userId)).OrderByDescending(t => t.Date));
        }

        private void Income()
        {
            _navigationService.ShowViewModel<AddIncomeTransactionViewModel>();
        }
    }
}