using Android.App;
using Android.OS;
using Android.Views;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.Droid.New.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize)]
    public class LoginActivity: BaseActivity<ReactiveLoginViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.sign_in);
        }
    }
}