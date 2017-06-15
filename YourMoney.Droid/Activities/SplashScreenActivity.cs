using Android.App;
using Android.OS;

namespace YourMoney.Droid.Activities
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/SplashTheme")]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
        }
    }
}

