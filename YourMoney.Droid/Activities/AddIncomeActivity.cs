
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using YourMoney.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Add Income")]
    public class AddIncomeActivity : BaseActivity<AddIncomeTransactionViewModel>
    {
        private IList<Binding> _bindings;

        private EditText _descriptionEditText;
        private EditText _categoryEditText;
        private EditText _valueEditText;
        private Button _addIncomeButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddIncome);

            _descriptionEditText = FindViewById<EditText>(Resource.Id.input_description);
            _categoryEditText = FindViewById<EditText>(Resource.Id.input_category);
            _valueEditText = FindViewById<EditText>(Resource.Id.input_value);
            _addIncomeButton = FindViewById<Button>(Resource.Id.AddTransactionButton);

            BindViewModel();
        }

        private void BindViewModel()
        {
            _bindings = new List<Binding>
            {
                this.SetBinding(() => ViewModel.Description, () => _descriptionEditText.Text, BindingMode.TwoWay),
                this.SetBinding(() => ViewModel.SelectedCategory, () => _categoryEditText.Text, BindingMode.TwoWay),
                this.SetBinding(() => ViewModel.Value, () => _valueEditText.Text, BindingMode.TwoWay)
            };

            _addIncomeButton.SetCommand(nameof(_addIncomeButton.Click), ViewModel.AddTransactionCommand);
        }
    }
}