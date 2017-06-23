
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using YourMoney.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Registration")]
    public class RegistrationActivity : BaseActivity<RegisterViewModel>
    {
        private IList<Binding> _bindings;

        private EditText _userNameEditText;
        private EditText _passwordEditText;
        private EditText _confirmPasswordEditText;
        private EditText _emailEditText;
        private TextView _errorTextView;
        private Button _registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Registration);

            _userNameEditText = FindViewById<EditText>(Resource.Id.input_userName);
            _passwordEditText = FindViewById<EditText>(Resource.Id.input_password);
            _confirmPasswordEditText = FindViewById<EditText>(Resource.Id.input_confirmPassword);
            _emailEditText = FindViewById<EditText>(Resource.Id.input_email);
            _errorTextView = FindViewById<TextView>(Resource.Id.ErrorTextView);
            _registerButton = FindViewById<Button>(Resource.Id.RegisterButton);

            BindModel();
        }

        private void BindModel()
        {
            _bindings = new List<Binding>
            {
                this.SetBinding(() => ViewModel.UserName, () => _userNameEditText.Text, BindingMode.TwoWay),
                this.SetBinding(() => ViewModel.Password, () => _passwordEditText.Text, BindingMode.TwoWay),
                this.SetBinding(() => ViewModel.ConfirmPassword, () => _confirmPasswordEditText.Text, BindingMode.TwoWay),
                this.SetBinding(() => ViewModel.Email, () => _emailEditText.Text, BindingMode.TwoWay),
                this.SetBinding(() => ViewModel.Error, () => _errorTextView.Text)
            };

            _registerButton.SetCommand(nameof(_registerButton.Click), ViewModel.RegisterCommand);
        }
    }
}