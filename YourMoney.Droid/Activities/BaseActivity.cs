using System;
using Android.App;
using Android.Support.V7.App;
using Autofac;
using ReactiveUI;
using YourMoney.Standard.Core;
using YourMoney.Standard.Core.ViewModels.Abstract;

namespace YourMoney.Droid.Activities
{
    [Activity]
    public class BaseActivity<T> : AppCompatActivity, IViewFor<T>
        where T : class, IViewModel
    {
        object IViewFor.ViewModel
        {
            get => AppStart.Container.Resolve<T>();
            set => throw new NotImplementedException();
        }

        public T ViewModel
        {
            get => AppStart.Container.Resolve<T>();
            set => throw new NotImplementedException();
        }

        protected override void OnStart()
        {
            base.OnStart();

            ViewModel.Appeared();
        }

        protected override void OnStop()
        {
            base.OnStop();

            ViewModel.Disappeared();
        }
    }
}