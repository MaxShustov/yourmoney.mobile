using Autofac;
using YourMoney.Core;
using YourMoney.Core.ViewModels;

namespace YourMoney.UWP
{
    public class ViewModelLocator
    {
        public ReactiveLoginViewModel LoginViewModel => AppStart.Container.Resolve<ReactiveLoginViewModel>();

        public ReactiveRegisterViewModel RegisterViewModel => AppStart.Container.Resolve<ReactiveRegisterViewModel>();

        public ReactiveHomeViewModel HomeViewModel => AppStart.Container.Resolve<ReactiveHomeViewModel>();

        //public AddIncomeTransactionViewModel AddIncomeTransactionViewModel => SimpleIoc.Default.GetInstance<AddIncomeTransactionViewModel>();
    }
}