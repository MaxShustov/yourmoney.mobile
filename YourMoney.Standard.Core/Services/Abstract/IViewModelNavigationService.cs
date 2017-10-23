namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface IViewModelNavigationService
    {
        void ShowViewModel<TViewModel>();

        void ShowViewModel<TViewModel>(object navigationParameter);

        void GoBack();
    }
}