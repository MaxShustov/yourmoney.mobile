using Autofac;
using YourMoney.Core;
using YourMoney.Core.ViewModels;

namespace YourMoney.UWP
{
    public class ViewModelLocator
    {
        public ReactiveLoginViewModel LoginViewModel => AppStart.Container.Resolve<ReactiveLoginViewModel>();

        //public LoginViewModel LoginViewModel => SimpleIoc.Default.GetInstance<LoginViewModel>();

        //public RegisterViewModel RegisterViewModel => SimpleIoc.Default.GetInstance<RegisterViewModel>();

        //public HomeViewModel HomeViewModel => SimpleIoc.Default.GetInstance<HomeViewModel>();

        //public AddIncomeTransactionViewModel AddIncomeTransactionViewModel => SimpleIoc.Default.GetInstance<AddIncomeTransactionViewModel>();
    }
}