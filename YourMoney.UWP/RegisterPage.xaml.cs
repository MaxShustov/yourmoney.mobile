using System;
using Windows.UI.Xaml.Controls;
using Autofac;
using ReactiveUI;
using Windows.UI.Xaml.Navigation;
using YourMoney.Standard.Core;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.UWP
{
    public sealed partial class RegisterPage : Page, IViewFor<ReactiveRegisterViewModel>
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => throw new NotImplementedException();
        }

        public ReactiveRegisterViewModel ViewModel
        {
            get => AppStart.Container.Resolve<ReactiveRegisterViewModel>();
            set => throw new NotImplementedException();
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
