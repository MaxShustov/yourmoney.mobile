using Android.App;
using Android.OS;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(Icon = "@drawable/icon", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : BaseActivity<SplashViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
        }

        protected override void OnStart()
        {
            base.OnStart();

            ViewModel.ShowFirstViewModel();
        }
    }
}

