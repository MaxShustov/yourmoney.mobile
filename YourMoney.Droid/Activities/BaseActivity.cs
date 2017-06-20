
using Android.App;
using Android.Support.V7.App;
using GalaSoft.MvvmLight.Ioc;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.Droid.Activities
{
    [Activity]
    public class BaseActivity<T> : AppCompatActivity
        where T : IViewModel
    {
        protected T ViewModel => SimpleIoc.Default.GetInstance<T>();

        protected override void OnStart()
        {
            base.OnRestart();

            ViewModel.Appeared();
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            ViewModel.Appearing();
        }
    }
}