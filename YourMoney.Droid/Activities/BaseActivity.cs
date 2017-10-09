
using System;
using Android.App;
using Android.Support.V7.App;
using Autofac;
using ReactiveUI;
using YourMoney.Core;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.Droid.Activities
{
    [Activity]
    public class BaseActivity<T> : AppCompatActivity, IViewFor<T>
        where T : class, IViewModel
    {
        object IViewFor.ViewModel
        {
            get
            {
                return AppStart.Container.Resolve<T>();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public T ViewModel
        {
            get
            {
                return AppStart.Container.Resolve<T>();
            }

            set
            {
                throw new NotImplementedException();
            }
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

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}