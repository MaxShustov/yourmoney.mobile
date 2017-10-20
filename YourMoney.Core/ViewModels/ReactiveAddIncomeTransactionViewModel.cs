using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
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
        private readonly ICategoriesService _categoriesService;
        private readonly IUserDialogs _userDialogs;
        
        private bool _isIncome;

        public ReactiveAddIncomeTransactionViewModel(ITransactionService transactionService, IViewModelNavigationService navigationService, ICategoriesService categoriesService, IUserDialogs userDialogs)
        {
            _transactionService = transactionService;
            _navigationService = navigationService;
            _categoriesService = categoriesService;
            _userDialogs = userDialogs;

            var isValidCategory = this.WhenAnyValue(m => m.SelectedCategory)
                .Select(c => c != null);

            var isValidValue = this.WhenAnyValue(m => m.Value)
                .Select(IsValidValue);

            var canAddTransaction = isValidCategory.Merge(isValidValue);

            AddTransactionCommand = ReactiveCommand.CreateFromTask(AddTransactionAsync, canAddTransaction);
            GetCategories = ReactiveCommand.CreateFromTask<Unit, IEnumerable<CategoryModel>>(GetCategoriesAsync);

            GetCategories
                .Select(categories => new ObservableCollection<CategoryModel>(categories))
                .Select(categories => new ReadOnlyObservableCollection<CategoryModel>(categories))
                .ToPropertyEx(this, vm => vm.Categories);

            AddTransactionCommand.ThrownExceptions.Subscribe(ex => _userDialogs.Alert(ex.Message));

            AddTransactionCommand
                .Subscribe(Observer.Create<Unit>(OnAddTransactionComplete));

            StateObservable
                .Where(s => s == ViewModelState.Disappered)
                .Subscribe(Observer.Create<ViewModelState>(ClearData));

            StateObservable.Where(s => s == ViewModelState.Appeared)
                .Select(_ => Unit.Default)
                .InvokeCommand(GetCategories);
        }

        [Reactive]
        public string Value { get; set; }

        [Reactive]
        public string Description { get; set; }
        
        [Reactive]
        public CategoryModel SelectedCategory { get; set; }

        public extern ReadOnlyObservableCollection<CategoryModel> Categories { [ObservableAsProperty] get; }

        public ReactiveCommand<Unit, Unit> AddTransactionCommand { get; }

        public ReactiveCommand<Unit, IEnumerable<CategoryModel>> GetCategories { get; }

        private Task<IEnumerable<CategoryModel>> GetCategoriesAsync(Unit _)
        {
            return _isIncome 
                ? _categoriesService.GetIncomeCategories()
                : _categoriesService.GetOutcomeCategories();
        }

        public override void InitWithParam(object navigationParam)
        {
            if (navigationParam is bool)
            {
                _isIncome = (bool) navigationParam;
            }
        }

        private Task AddTransactionAsync()
        {
            var sign = _isIncome ? 1 : -1;

            var transaction = new Transaction
            {
                Description = Description,
                Value = Convert.ToDecimal(Value) * sign,
                Category = SelectedCategory.Name,
            };

            return _transactionService.AddTransaction(transaction);
        }

        private bool IsValidValue(string value)
        {
            return !string.IsNullOrWhiteSpace(value) 
                && decimal.TryParse(value, NumberStyles.Float, CultureInfo.CurrentUICulture, out decimal decimalValue) 
                && decimalValue > 0;
        }

        private void OnAddTransactionComplete(Unit unit)
        {
            _navigationService.GoBack();
        }

        private void ClearData(ViewModelState state)
        {
            Value = null;
            Description = string.Empty;
            SelectedCategory = null;
        }
    }
}