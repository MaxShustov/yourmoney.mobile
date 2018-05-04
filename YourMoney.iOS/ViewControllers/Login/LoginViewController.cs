using System;

using UIKit;
using ReactiveUI;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.iOS.ViewControllers.Login
{
    public partial class LoginViewController : BaseViewController<ReactiveLoginViewModel>
    {
        public LoginViewController()
            : base("LoginViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = true;

            Theme.AsPrimaryButton(ClickMeButton);
            Theme.AsDarkButton(RegisterButton);

            this.Bind(ViewModel, vm => vm.UserName, v => v.LoginTextField.Text);
            this.Bind(ViewModel, vm => vm.Password, v => v.PasswordTextField.Text);
            this.Bind(ViewModel, vm => vm.Error, v => v.ErrorLabel.Text);

            this.OneWayBind(ViewModel, vm => vm.IsUiEnabled, v => v.LoginTextField.Enabled);
            this.OneWayBind(ViewModel, vm => vm.IsUiEnabled, v => v.PasswordTextField.Enabled);
            this.OneWayBind(ViewModel, vm => vm.IsUiEnabled, v => v.ClickMeButton.Enabled);
            this.OneWayBind(ViewModel, vm => vm.IsUiEnabled, v => v.RegisterButton.Enabled);

            this.BindCommand(ViewModel, vm => vm.LoginCommand, v => v.ClickMeButton, nameof(ClickMeButton.TouchUpInside));
            this.BindCommand(ViewModel, vm => vm.RegisterCommand, v => v.RegisterButton, nameof(RegisterButton.TouchUpInside));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}

