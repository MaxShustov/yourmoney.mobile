using System;
using Android.App;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.Droid.New.Activities
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true)]
    public class SplashActivity : BaseActivity<SplashViewModel>
    {
        protected override void OnStart()
        {
            base.OnStart();

            ViewModel.ShowFirstViewModel();
        }

        public override void NavigateTo<TNextViewModel>()
        {
            var nextViewModelType = typeof(TNextViewModel);

            if (nextViewModelType == typeof(ReactiveLoginViewModel))
            {
                StartActivity(typeof(LoginActivity));
            }
            else if (nextViewModelType == typeof(ReactiveHomeViewModel))
            {
            }
            else
            {
                throw new ArgumentException($"Not able to navigate to {typeof(TNextViewModel).Name}");
            }
        }
    }
}