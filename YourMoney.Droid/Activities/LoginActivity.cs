using Android.App;
using Android.OS;
using Android.Widget;
using ReactiveUI;
using YourMoney.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Login", Theme = "@style/AppTheme")]
    public class LoginActivity : BaseActivity<ReactiveLoginViewModel>
    {
        public EditText UserNameEditText { get; set; }

        public EditText PasswordEditText { get; set; }

        public Button LoginButton { get; set; }

        public Button RegisterButton { get; set; }

        public TextView ErrorTextView { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            this.WireUpControls();

            BindViewModel();
        }

        private void BindViewModel()
        {
            this.Bind(ViewModel, m => m.UserName, a => a.UserNameEditText.Text);
            this.Bind(ViewModel, m => m.Password, a => a.PasswordEditText.Text);
            this.OneWayBind(ViewModel, m => m.Error, a => a.ErrorTextView.Text);

            this.BindCommand(ViewModel, m => m.LoginCommand, a => a.LoginButton, "Click");
        }
    }
}