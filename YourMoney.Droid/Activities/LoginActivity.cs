using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using YourMoney.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Login", Theme = "@style/AppTheme")]
    public class LoginActivity : BaseActivity<LoginViewModel>
    {
        public EditText _userNameEditText { get; set; }
        private EditText _passwordEditText;
        public Button _loginButton { get; set; }
        public Button _registerButton { get; set; }
        private TextView _errorTextView;
        private IList<Binding> _bindings;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            _userNameEditText = FindViewById<EditText>(Resource.Id.input_login);
            _passwordEditText = FindViewById<EditText>(Resource.Id.input_password);
            _loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            _registerButton = FindViewById<Button>(Resource.Id.RegisterButton);
            _errorTextView = FindViewById<TextView>(Resource.Id.ErrorTextView);

            _userNameEditText.Text = string.Empty;

            BindViewModel();
        }

        private void BindViewModel()
        {
            _bindings = new List<Binding>
            {
                this.SetBinding(() => ViewModel.UserName, () => _userNameEditText.Text, BindingMode.TwoWay),
                this.SetBinding(() => _userNameEditText.Enabled, () => ViewModel.IsUiEnabled),
                this.SetBinding(() => _passwordEditText.Text, () => ViewModel.Password, BindingMode.TwoWay),
                this.SetBinding(() => _passwordEditText.Enabled, () => ViewModel.IsUiEnabled),
                this.SetBinding(() => _passwordEditText.Enabled, () => ViewModel.IsUiEnabled),
                this.SetBinding(() => _registerButton.Enabled, () => ViewModel.IsUiEnabled)
            };

            _loginButton.SetCommand(ViewModel.LoginCommand);
            _registerButton.SetCommand(ViewModel.RegisterCommand);
        }
    }
}