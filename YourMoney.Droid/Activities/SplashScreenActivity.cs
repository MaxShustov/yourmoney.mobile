using Android.App;
using Android.OS;

namespace YourMoney.Droid.Activities
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

