using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace YourMoney.Droid.RecyclerViews.ViewHolders
{
    public class TransactionViewHolder : RecyclerView.ViewHolder
    {
        public TextView DateTextView { get; }

        public TextView CategoryTextView { get; }

        public TextView DescriptionTextView { get; }

        public TextView ValueTextView { get; }

        public TransactionViewHolder(View itemView)
            : base(itemView)
        {
            DateTextView = itemView.FindViewById<TextView>(Resource.Id.DateTimeTextView);
            CategoryTextView = itemView.FindViewById<TextView>(Resource.Id.CategoryTextView);
            DescriptionTextView = itemView.FindViewById<TextView>(Resource.Id.DescriptionTextView);
            ValueTextView = itemView.FindViewById<TextView>(Resource.Id.ValueTextView);
        }
    }
}