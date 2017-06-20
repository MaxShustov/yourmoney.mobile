using GalaSoft.MvvmLight;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class BaseViewModel : ViewModelBase, IViewModel
    {
        public virtual void Appearing()
        {
        }

        public virtual void Appeared()
        {
        }

        public virtual void Disappearing()
        {
        }

        public virtual void Disappeared()
        {
        }
    }
}