using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using YourMoney.Core.Enums;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class ReactiveAddIncomeTransactionViewModel : BaseViewModel
    {
        private readonly ITransactionService _transactionService;
        private readonly IViewModelNavigationService _navigationService;

        public ReactiveAddIncomeTransactionViewModel(ITransactionService transactionService, IViewModelNavigationService navigationService)
        {
            _transactionService = transactionService;
            _navigationService = navigationService;

            var isValidStringData = this.WhenAnyValue(m => m.Category, m => m.Description)
                .Select(t => IsValidStringData(t.Item1, t.Item2));

            var isValidValue = this.WhenAnyValue(m => m.Value)
                .Select(IsValidValue);

            var canAddTransaction = isValidStringData.Merge(isValidValue);

            AddTransactionCommand = ReactiveCommand.CreateFromTask(AddTransactionAsync, canAddTransaction);

            AddTransactionCommand
                .Subscribe(Observer.Create<Unit>(OnAddTransactionComplete));

            StateObservable
                .Where(s => s == ViewModelState.Disappered)
                .Subscribe(Observer.Create<ViewModelState>(ClearData));
        }

        [Reactive]
        public double Value { get; set; }

        [Reactive]
        public string Description { get; set; }

        [Reactive]
        public string Category { get; set; }

        public ReactiveCommand<Unit, Unit> AddTransactionCommand { get; }

        private Task AddTransactionAsync()
        {
            var transaction = new Transaction
            {
                Description = Description,
                Value = (decimal)Value,
                Category = Category
            };

            return _transactionService.AddTransaction(transaction);
        }

        private bool IsValidStringData(string category, string description)
        {
            return !string.IsNullOrWhiteSpace(category) && !string.IsNullOrWhiteSpace(description);
        }

        private bool IsValidValue(double value)
        {
            return value > 0.0;
        }

        private void OnAddTransactionComplete(Unit unit)
        {
            _navigationService.GoBack();
        }

        private void ClearData(ViewModelState state)
        {
            Value = 0;
            Description = string.Empty;
            Category = string.Empty;
        }
    }
}