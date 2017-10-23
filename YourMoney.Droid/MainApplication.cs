using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Autofac;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Plugin.CurrentActivity;
using Plugin.Settings;
using YourMoney.Droid.Services;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core;

namespace YourMoney.Droid
{
    //You can specify additional application information in this attribute
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
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!

            MobileCenter.Start("7f6abd3a-30bc-40f0-a2da-101eb68d2ce5", typeof(Analytics));

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
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
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