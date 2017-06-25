namespace YourMoney.Core.Services.Abstract
{
    public interface IViewModelNavigationService
    {
        void ShowViewModel<TViewModel>();

        void GoBack();
    }
}