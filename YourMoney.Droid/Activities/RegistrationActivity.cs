using Android.App;
using Android.OS;
using Android.Widget;
using ReactiveUI;
using ReactiveUI.AndroidSupport;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(Label = "Registration")]
    public class RegistrationActivity : BaseActivity<ReactiveRegisterViewModel>
    {
        public EditText UserNameEditText { get; set; }

        public EditText PasswordEditText { get; set; }

        public EditText ConfirmPassword { get; set; }

        public EditText EmailEditText { get; set; }

        public TextView ErrorTextView { get; set; }

        public Button RegisteButton { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Registration);

            this.WireUpControls();

            BindModel();
        }

        private void BindModel()
        {
            this.Bind(ViewModel, m => m.UserName, a => a.UserNameEditText.Text);
            this.Bind(ViewModel, m => m.Password, a => a.PasswordEditText.Text);
            this.Bind(ViewModel, m => m.ConfirmPassword, a => a.ConfirmPassword.Text);
            this.Bind(ViewModel, m => m.Email, a => a.EmailEditText.Text);
            this.OneWayBind(ViewModel, m => m.Error, a => a.ErrorTextView.Text);

            this.OneWayBind(ViewModel, m => m.IsUiEnabled, a => a.UserNameEditText.Enabled);
            this.OneWayBind(ViewModel, m => m.IsUiEnabled, a => a.ConfirmPassword.Enabled);
            this.OneWayBind(ViewModel, m => m.IsUiEnabled, a => a.PasswordEditText.Enabled);
            this.OneWayBind(ViewModel, m => m.IsUiEnabled, a => a.EmailEditText.Enabled);
            this.OneWayBind(ViewModel, m => m.IsUiEnabled, a => a.RegisteButton.Enabled);

            this.BindCommand(ViewModel, m => m.RegisterCommand, a => a.RegisteButton, "Click");
        }
    }
}