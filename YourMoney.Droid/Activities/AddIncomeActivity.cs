using Android.App;
using Android.OS;
using Android.Widget;
using ReactiveUI;
using ReactiveUI.AndroidSupport;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Add Income")]
    public class AddIncomeActivity : BaseActivity<ReactiveAddIncomeTransactionViewModel>
    {
        public EditText DescriptionEditText { get; set; }

        public EditText CategoryEditText { get; set; }

        public EditText ValueEditText { get; set; }

        public Button AddIncomeButton { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddIncome);

            this.WireUpControls();

            BindViewModel();
        }

        private void BindViewModel()
        {
            this.Bind(ViewModel, m => m.Description, a => a.DescriptionEditText.Text);
            this.Bind(ViewModel, m => m.Value, a => a.ValueEditText.Text);

            //this.BindCommand(ViewModel, m => m.AddTransactionCommand, a => a.AddIncomeButton, nameof(AddIncomeButton.Click));
        }
    }
}