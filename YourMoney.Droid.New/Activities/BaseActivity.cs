using Android.Support.V7.App;
using Autofac;
using ReactiveUI;
using YourMoney.Standard.Core;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Droid.New.Activities
{
    public class BaseActivity<TViewModel> : AppCompatActivity, IViewFor<TViewModel>, IPageRouter<TViewModel>
        where TViewModel: class
    {
        protected INavigationHelper NavigationHelper => AppStart.Container.Resolve<INavigationHelper>();

        public TViewModel ViewModel
        {
            get => AppStart.Container.Resolve<TViewModel>(new TypedParameter(typeof(IPageRouter<TViewModel>), this)); 
            set => throw new System.NotImplementedException();
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => throw new System.NotImplementedException();
        }

        public virtual void NavigateTo<TNextViewModel>()
        {
        }
    }
}