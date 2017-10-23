using Autofac;
using YourMoney.Standard.Core;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.UWP
{
    public class ViewModelLocator
    {
        public ReactiveLoginViewModel LoginViewModel => AppStart.Container.Resolve<ReactiveLoginViewModel>();

        public ReactiveRegisterViewModel RegisterViewModel => AppStart.Container.Resolve<ReactiveRegisterViewModel>();

        public ReactiveHomeViewModel HomeViewModel => AppStart.Container.Resolve<ReactiveHomeViewModel>();

        public ReactiveAddIncomeTransactionViewModel AddIncomeTransactionViewModel => AppStart.Container.Resolve<ReactiveAddIncomeTransactionViewModel>();
    }
}