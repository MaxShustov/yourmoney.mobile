using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
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

            GetTransactionsCommand = ReactiveCommand.CreateFromTask(GetTransactions);

            GetTransactionsCommand
                .Select(transactions => transactions.OrderByDescending(t => t.Date))
                .Select(ToObservableCollection)
                .Select(transactions => new ReadOnlyObservableCollection<Transaction>(transactions))
                .ToPropertyEx(this, m => m.Transactions);

            GetCurrentBalanceCommand = ReactiveCommand.CreateFromTask(GetCurrentBalance);

            GetCurrentBalanceCommand
                .Select(b => $"{RegionInfo.CurrentRegion.CurrencySymbol}{b}")
                .ToPropertyEx(this, m => m.CurrentBalance);
        }

        public ReactiveCommand<Unit, Unit> IncomeCommand { get; }

        public ReactiveCommand<Unit, Unit> OutcomeCommand { get; }

        public ReactiveCommand<Unit, List<Transaction>> GetTransactionsCommand { get; }

        public ReactiveCommand<Unit, decimal> GetCurrentBalanceCommand { get; }

        public extern string CurrentBalance { [ObservableAsProperty] get; }

        public extern ReadOnlyObservableCollection<Transaction> Transactions { [ObservableAsProperty] get; }

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
            await GetTransactionsCommand.Execute();
            await GetCurrentBalanceCommand.Execute();
        }

        private Task<List<Transaction>> GetTransactions()
        {
            return _userService.GetTransactions(_userId);
        }

        private ObservableCollection<Transaction> ToObservableCollection(IEnumerable<Transaction> transactions)
        {
            return new ObservableCollection<Transaction>(transactions);
        }

        private Task<decimal> GetCurrentBalance()
        {
            return _userService.GetCurrentBalance(_userId);
        }
    }
}