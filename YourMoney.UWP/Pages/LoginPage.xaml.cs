using Autofac;
using ReactiveUI;
using Windows.UI.Xaml.Controls;
using YourMoney.Core;
using YourMoney.Core.ViewModels;

namespace YourMoney.UWP.Pages
{
    public sealed partial class LoginPage : Page, IViewFor<ReactiveLoginViewModel>
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        object IViewFor.ViewModel
        {
            get
            {
                return ViewModel;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public ReactiveLoginViewModel ViewModel
        {
            get
            {
                return AppStart.Container.Resolve<ReactiveLoginViewModel>();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
