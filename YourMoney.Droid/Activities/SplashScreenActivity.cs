using System.Threading.Tasks;
using Android.App;
using Android.OS;

namespace YourMoney.Droid.Activities
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/SplashTheme")]
    public class SplashScreenActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            await GoToLogin();
        }

        private async Task GoToLogin()
        {
            await Task.Delay(1000);

            StartActivity(typeof(LoginActivity));
        }
    }
}

