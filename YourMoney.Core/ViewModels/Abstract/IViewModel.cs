namespace YourMoney.Core.ViewModels.Abstract
{
    public interface IViewModel
    {
        void InitWithParam(object navigationParam);

        void Appearing();

        void Appeared();

        void Disappearing();

        void Disappeared();
    }
}