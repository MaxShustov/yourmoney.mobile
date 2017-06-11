using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class AddIncomeTransactionViewModel : ViewModelBase
    {
        private readonly ITransactionService _transactionService;

        private decimal _value;
        private string _description;
        private string _category;

        public AddIncomeTransactionViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public ICommand AddTransactionCommand => new RelayCommand(AddTransaction);

        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                Set(() => Value, ref _value, value);
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                Set(() => Description, ref _description, value);
            }
        }

        public string SelectedCategory
        {
            get
            {
                return _category;
            }
            set
            {
                Set(() => SelectedCategory, ref _category, value);
            }
        }

        private async void AddTransaction()
        {
            var transaction = new Transaction
            {
                Description = Description,
                Value = Value,
                Category = SelectedCategory
            };

            await _transactionService.AddTransaction(transaction);
        }
    }
}