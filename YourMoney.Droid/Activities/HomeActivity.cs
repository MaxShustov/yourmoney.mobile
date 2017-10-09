using System.Reactive;
using System.Reactive.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Clans.Fab;
using ReactiveUI;
using YourMoney.Core.Enums;
using YourMoney.Core.ViewModels;
using YourMoney.Droid.RecyclerViews;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Home")]
    public class HomeActivity : BaseActivity<ReactiveHomeViewModel>
    {
        private LinearLayoutManager _layoutManager;

        public RecyclerView TransactionRecyclerView { get; private set; }
        public TextView CurrentBalanceTextView { get; private set; }
        public FloatingActionButton AddIncomeButton { get; private set; }
        public FloatingActionButton AddOutcomeButton { get; private set; }
        public TransactionsAdapter TransactionsAdapter { get; private set; }
        public FloatingActionMenu FloatingActionMenu { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            this.WireUpControls();

            TransactionsAdapter = new TransactionsAdapter();

            _layoutManager = new LinearLayoutManager(this);

            TransactionRecyclerView.SetLayoutManager(_layoutManager);
            TransactionRecyclerView.SetAdapter(TransactionsAdapter);

            BindViewModel();
        }

        private void BindViewModel()
        {
            AddIncomeButton.Events().Click
                .Select(e => Unit.Default)
                .InvokeCommand(ViewModel, m => m.IncomeCommand);

            AddOutcomeButton.Events().Click
                .Select(e => Unit.Default)
                .InvokeCommand(ViewModel, m => m.OutcomeCommand);

            this.OneWayBind(ViewModel, m => m.CurrentBalance, a => a.CurrentBalanceTextView.Text);
            this.OneWayBind(ViewModel, m => m.Transactions, a => a.TransactionsAdapter.ItemSource);

            var disappearedObserver = Observer.Create<ViewModelState>(CloseMenu);

            ViewModel.StateObservable
                .Where(state => state == ViewModelState.Disappered)
                .Subscribe(disappearedObserver);
        }

        private void CloseMenu(ViewModelState state)
        {
            FloatingActionMenu.Close(false);
        }
    }
}