using YourMoney.Standard.Core.ViewModels.Abstract;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface IPageRouter<TViewModel>
    {
        void NavigateTo<TNextViewModel>();
    }
}