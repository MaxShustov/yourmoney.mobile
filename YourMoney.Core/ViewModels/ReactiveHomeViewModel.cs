using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using YourMoney.Core.Enums;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class ReactiveHomeViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly ISettingService _settingService;
        private readonly IViewModelNavigationService _navigationService;
        private readonly ITransactionService _transactionService;

        public ReactiveHomeViewModel(IUserService userService, ISettingService settingService, IViewModelNavigationService navigationService, ITransactionService transactionService)
        {
            _userService = userService;
            _settingService = settingService;
            _navigationService = navigationService;
            _transactionService = transactionService;

            IncomeCommand = ReactiveCommand.Create(Income);
            OutcomeCommand = ReactiveCommand.Create(Outcome);
            GetTransactionsCommand = ReactiveCommand.CreateFromTask<Unit, IEnumerable<Transaction>>(GetTransactions);
            GetCurrentBalanceCommand = ReactiveCommand.CreateFromTask<Unit, decimal>(GetCurrentBalance);

            GetTransactionsCommand
                .Select(transactions => transactions.OrderByDescending(t => t.Date))
                .Select(ToObservableCollection)
                .Select(transactions => new ReadOnlyObservableCollection<Transaction>(transactions))
                .ToPropertyEx(this, m => m.Transactions);

            var currentBalanceObservable = GetCurrentBalanceCommand
                .Select(b => $"{RegionInfo.CurrentRegion.CurrencySymbol}{b}");

            currentBalanceObservable
                .ToPropertyEx(this, m => m.CurrentBalance);

            currentBalanceObservable
                .Select(s => $"Your balance is: {s}")
                .ToPropertyEx(this, m => m.FullCurrentBalance);

            StateObservable
                .Where(state => state == ViewModelState.Appeared)
                .Select(s => Unit.Default)
                .InvokeCommand(GetCurrentBalanceCommand);

            StateObservable
                .Where(state => state == ViewModelState.Appeared)
                .Select(s => Unit.Default)
                .InvokeCommand(GetTransactionsCommand);
        }

        public ReactiveCommand<Unit, Unit> IncomeCommand { get; }

        public ReactiveCommand<Unit, Unit> OutcomeCommand { get; }

        public ReactiveCommand<Unit, IEnumerable<Transaction>> GetTransactionsCommand { get; }

        public ReactiveCommand<Unit, decimal> GetCurrentBalanceCommand { get; }

        public extern string CurrentBalance { [ObservableAsProperty] get; }

        public extern string FullCurrentBalance { [ObservableAsProperty] get; }

        public extern ReadOnlyObservableCollection<Transaction> Transactions { [ObservableAsProperty] get; }

        private void Income()
        {
            _navigationService.ShowViewModel<ReactiveAddIncomeTransactionViewModel>();
        }

        private void Outcome()
        {

        }

        private Task<IEnumerable<Transaction>> GetTransactions(Unit _)
        {
            return _transactionService.GetTransactions();
        }

        private Task<decimal> GetCurrentBalance(Unit _)
        {
            return _transactionService.GetTotalSum();
        }

        private ObservableCollection<Transaction> ToObservableCollection(IEnumerable<Transaction> transactions)
        {
            return new ObservableCollection<Transaction>(transactions);
        }
    }
}