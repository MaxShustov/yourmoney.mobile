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

            this.Bind(ViewModel, vm => vm.UserName, v => v.LoginTextField.Text);
            this.Bind(ViewModel, vm => vm.Password, v => v.PasswordTextField.Text);
            this.Bind(ViewModel, vm => vm.Error, v => v.ErrorLabel.Text);

            this.BindCommand(ViewModel, vm => vm.LoginCommand, v => v.ClickMeButton, nameof(ClickMeButton.TouchUpInside));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

