﻿using Android.App;
using Android.OS;
using YourMoney.Core.ViewModels;

namespace YourMoney.Droid.Activities
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/SplashTheme")]
    public class SplashScreenActivity : BaseActivity<SplashViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
        }

        protected override void OnStart()
        {
            base.OnStart();

            ViewModel.ShowFirstViewModel();
        }
    }
}

