using GalaSoft.MvvmLight.Views;

namespace YourMoney.Core.Services.Abstract
{
    public interface IViewModelNavigationService : INavigationService
    {
        void ShowViewModel<TViewModel>();
    }
}