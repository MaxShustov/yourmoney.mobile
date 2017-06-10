using GalaSoft.MvvmLight.Ioc;
using YourMoney.Core.ViewModels;

namespace YourMoney.UWP
{
    public class ViewModelLocator
    {
        public LoginViewModel LoginViewModel => SimpleIoc.Default.GetInstance<LoginViewModel>();

        public RegisterViewModel RegisterViewModel => SimpleIoc.Default.GetInstance<RegisterViewModel>();
    }
}