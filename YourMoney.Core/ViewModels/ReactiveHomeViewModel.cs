using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class ReactiveHomeViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly ISettingService _settingService;
        private readonly IViewModelNavigationService _navigationService;
        private readonly string _userId;

        public ReactiveHomeViewModel(IUserService userService, ISettingService settingService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _settingService = settingService;
            _navigationService = navigationService;

            _userId = settingService.UserId;

            IncomeCommand = ReactiveCommand.Create(Income);
            OutcomeCommand = ReactiveCommand.Create(Outcome);
        }

        public ReactiveCommand<Unit, Unit> IncomeCommand { get; }

        public ReactiveCommand<Unit, Unit> OutcomeCommand { get; }

        [Reactive]
        public string CurrentBalance { get; set; }

        [Reactive]
        public ReadOnlyObservableCollection<Transaction> Transactions { get; set; } = new ReadOnlyObservableCollection<Transaction>(new ObservableCollection<Transaction>());

        public override void Appeared()
        {
            base.Appeared();

            GetData();
        }

        private void Income()
        {
        }

        private void Outcome()
        {

        }

        private async void GetData()
        {
            var observableCollection = new ObservableCollection<Transaction>((await _userService.GetTransactions(_userId)).OrderByDescending(t => t.Date));
            var currentBallance = await _userService.GetCurrentBalance(_userId);

            CurrentBalance = $"{RegionInfo.CurrentRegion.CurrencySymbol}{currentBallance}";
            Transactions = new ReadOnlyObservableCollection<Transaction>(observableCollection);
        }
    }
}