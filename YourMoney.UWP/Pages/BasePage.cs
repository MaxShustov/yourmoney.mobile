using System;
using ReactiveUI;
using Windows.UI.Xaml.Controls;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.UWP.Pages
{
    public class BasePage<TViewModel> : Page, IViewFor<TViewModel>
        where TViewModel : ReactiveObject, IViewModel
    {
        object IViewFor.ViewModel
        {
            get
            {
                return ViewModel;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TViewModel ViewModel
        {
            get
            {
                return ViewModel;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
