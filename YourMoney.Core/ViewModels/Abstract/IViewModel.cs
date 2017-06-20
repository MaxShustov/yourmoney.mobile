namespace YourMoney.Core.ViewModels.Abstract
{
    public interface IViewModel
    {
        void Appearing();

        void Appeared();

        void Disappearing();

        void Disappeared();
    }
}