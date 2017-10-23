using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Enums;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.ViewModels
{
    public class ReactiveHomeViewModel : BaseViewModel
    {
        private readonly IViewModelNavigationService _navigationService;
        private readonly ITransactionService _transactionService;

        private readonly ObservableAsPropertyHelper<ReadOnlyObservableCollection<TransactionModel>> _transactions;
        private readonly ObservableAsPropertyHelper<string> _currentBalance;
        private readonly ObservableAsPropertyHelper<string> _fullCurrentBalance;

        public ReactiveHomeViewModel(IViewModelNavigationService navigationService, ITransactionService transactionService)
        {
            _navigationService = navigationService;
            _transactionService = transactionService;

            IncomeCommand = ReactiveCommand.Create(Income);
            OutcomeCommand = ReactiveCommand.Create(Outcome);
            GetTransactionsCommand = ReactiveCommand.CreateFromTask<Unit, IEnumerable<TransactionModel>>(GetTransactions);
            GetCurrentBalanceCommand = ReactiveCommand.CreateFromTask<Unit, decimal>(GetCurrentBalance);

            _transactions = GetTransactionsCommand
                .Select(transactions => transactions.OrderByDescending(t => t.Date))
                .Select(ToObservableCollection)
                .Select(transactions => new ReadOnlyObservableCollection<TransactionModel>(transactions))
                .ToProperty(this, m => m.Transactions);

            var currentBalanceObservable = GetCurrentBalanceCommand
                .Select(b => $"{RegionInfo.CurrentRegion.CurrencySymbol}{b}");

            _currentBalance = currentBalanceObservable
                .ToProperty(this, m => m.CurrentBalance, string.Empty);

            _fullCurrentBalance = currentBalanceObservable
                .Select(s => $"Your balance is: {s}")
                .ToProperty(this, m => m.FullCurrentBalance, string.Empty);

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

        public ReactiveCommand<Unit, IEnumerable<TransactionModel>> GetTransactionsCommand { get; }

        public ReactiveCommand<Unit, decimal> GetCurrentBalanceCommand { get; }

        public string CurrentBalance => _currentBalance.Value;

        public string FullCurrentBalance => _fullCurrentBalance.Value;

        public ReadOnlyObservableCollection<TransactionModel> Transactions => _transactions.Value;

        private void Income()
        {
            var a = 0;
            var b = 7 / a;

            _navigationService.ShowViewModel<ReactiveAddIncomeTransactionViewModel>(true);
        }

        private void Outcome()
        {
            _navigationService.ShowViewModel<ReactiveAddIncomeTransactionViewModel>(false);
        }

        private Task<IEnumerable<TransactionModel>> GetTransactions(Unit _)
        {
            return _transactionService.GetTransactions();
        }

        private Task<decimal> GetCurrentBalance(Unit _)
        {
            return _transactionService.GetTotalSum();
        }

        private ObservableCollection<TransactionModel> ToObservableCollection(IEnumerable<TransactionModel> transactions)
        {
            return new ObservableCollection<TransactionModel>(transactions);
        }
    }
}