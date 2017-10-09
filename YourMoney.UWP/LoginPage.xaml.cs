using Autofac;
using ReactiveUI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using YourMoney.Core;
using YourMoney.Core.ViewModels;

namespace YourMoney.UWP
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

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            ViewModel.Disappeared();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel.Appeared();
        }
    }
}
