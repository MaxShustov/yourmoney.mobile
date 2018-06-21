using System.Collections.ObjectModel;
using System.Globalization;
using Android.Support.V7.Widget;
using Android.Views;
using YourMoney.Droid.RecyclerViews.ViewHolders;
using YourMoney.Standard.Core.Api.Models;

namespace YourMoney.Droid.RecyclerViews
{
    public class TransactionsAdapter : RecyclerView.Adapter
    {
        private ReadOnlyObservableCollection<TransactionModel> _itemSource;

        public TransactionsAdapter()
        {
            _itemSource = new ReadOnlyObservableCollection<TransactionModel>(new ObservableCollection<TransactionModel>());
        }

        public override int ItemCount => _itemSource.Count;

        public ReadOnlyObservableCollection<TransactionModel> ItemSource
        {
            get => _itemSource;
            set
            {
                _itemSource = value ?? new ReadOnlyObservableCollection<TransactionModel>(new ObservableCollection<TransactionModel>());

                NotifyDataSetChanged();
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var transactionViewHolder = (TransactionViewHolder)holder;
            var transaction = ItemSource[position];

            transactionViewHolder.DateTextView.Text = transaction.Date.ToString(CultureInfo.CurrentCulture);
            transactionViewHolder.CategoryTextView.Text = transaction.Category;
            transactionViewHolder.DescriptionTextView.Text = transaction.Description;
            transactionViewHolder.ValueTextView.Text = transaction.Value.ToString(CultureInfo.CurrentCulture);
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