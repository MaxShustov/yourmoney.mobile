using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Autofac;
using Plugin.CurrentActivity;
using Plugin.Settings;
using YourMoney.Droid.Services;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

namespace YourMoney.Droid
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            CrossCurrentActivity.Current.Init(this);

            RegisterActivityLifecycleCallbacks(this);

            AppCenter.Start("2408931e-943c-41f9-9adf-d44fdcaa8206", typeof(Analytics), typeof(Crashes));

            AppStart.Initialize(RegisterAndroidDependencies);
        }

        private void RegisterAndroidDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<ViewModelNavigationService>().As<IViewModelNavigationService>();
            builder.Register(c => CrossCurrentActivity.Current).As<ICurrentActivity>();
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Init(this);
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}