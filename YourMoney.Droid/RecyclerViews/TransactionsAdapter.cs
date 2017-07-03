using System.Collections.ObjectModel;
using System.Globalization;
using Android.Support.V7.Widget;
using Android.Views;
using YourMoney.Core.Models;
using YourMoney.Droid.RecyclerViews.ViewHolders;

namespace YourMoney.Droid.RecyclerViews
{
    public class TransactionsAdapter : RecyclerView.Adapter
    {
        private ReadOnlyObservableCollection<Transaction> _itemSource;

        public TransactionsAdapter()
        {
            _itemSource = new ReadOnlyObservableCollection<Transaction>(new ObservableCollection<Transaction>());
        }

        public override int ItemCount => _itemSource.Count;

        public ReadOnlyObservableCollection<Transaction> ItemSource
        {
            get
            {
                return _itemSource;
            }
            set
            {
                _itemSource = value ?? new ReadOnlyObservableCollection<Transaction>(new ObservableCollection<Transaction>());

                NotifyDataSetChanged();
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var transactionViewHolder = (TransactionViewHolder)holder;
            var transaction = ItemSource[position];

            transactionViewHolder.DateTextView.Text = transaction.Date.ToString(CultureInfo.CurrentUICulture);
            transactionViewHolder.CategoryTextView.Text = transaction.Category;
            transactionViewHolder.DescriptionTextView.Text = transaction.Description;
            transactionViewHolder.ValueTextView.Text = transaction.Value.ToString(CultureInfo.CurrentUICulture);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.transactionItemTemplate, parent, false);

            var viewHolder = new TransactionViewHolder(itemView);

            return viewHolder;
        }
    }
}