using System;
using Windows.UI.Xaml.Controls;
using Autofac;
using ReactiveUI;
using YourMoney.Core;
using YourMoney.Core.ViewModels;

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
            get
            {
                return ViewModel;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ReactiveRegisterViewModel ViewModel
        {
            get
            {
                return AppStart.Container.Resolve<ReactiveRegisterViewModel>();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
