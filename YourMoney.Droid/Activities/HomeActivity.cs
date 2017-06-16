using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using YourMoney.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Home")]
    public class HomeActivity : BaseActivity<HomeViewModel>
    {
        private IList<Binding> _bindings;

        private RecyclerView _recyclerView;
        private TextView _currentBalance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.transactionRecyclerView);
            _currentBalance = FindViewById<TextView>(Resource.Id.BalanceTextView);

            BindViewModel();
        }

        private void BindViewModel()
        {
            _bindings = new List<Binding>
            {
                this.SetBinding(() => ViewModel.CurrentBalance, () => _currentBalance.Text)
            };
        }
    }
}