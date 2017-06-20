using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using Clans.Fab;
using GalaSoft.MvvmLight.Helpers;
using YourMoney.Core.ViewModels;
using YourMoney.Droid.RecyclerViews;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Home")]
    public class HomeActivity : BaseActivity<HomeViewModel>
    {
        private IList<Binding> _bindings;

        private RecyclerView _recyclerView;
        private TextView _currentBalance;
        private TransactionsAdapter _adapter;
        private LinearLayoutManager _layoutManager;
        private FloatingActionButton _addIncomeButton;
        private FloatingActionButton _addOutcomeButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.transactionRecyclerView);
            _currentBalance = FindViewById<TextView>(Resource.Id.BalanceTextView);
            _addIncomeButton = FindViewById<FloatingActionButton>(Resource.Id.addIncomeButton);
            _addOutcomeButton = FindViewById<FloatingActionButton>(Resource.Id.addOutcomeButton);

            _adapter = new TransactionsAdapter();

            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);
            _recyclerView.SetAdapter(_adapter);

            BindViewModel();
        }

        private void BindViewModel()
        {
            _bindings = new List<Binding>
            {
                this.SetBinding(() => ViewModel.CurrentBalance, () => _currentBalance.Text),
                this.SetBinding(() => ViewModel.Transactions, () => _adapter.ItemSource)
            };
            
            _addIncomeButton.SetCommand("Click", ViewModel.IncomeCommand);
        }
    }
}