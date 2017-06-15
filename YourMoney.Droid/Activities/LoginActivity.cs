using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Login", Theme = "@style/AppTheme")]
    public class LoginActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);
        }
    }
}