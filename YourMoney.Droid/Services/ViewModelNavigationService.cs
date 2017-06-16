using System;
using System.Collections.Generic;
using Plugin.CurrentActivity;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.ViewModels;
using YourMoney.Droid.Activities;

namespace YourMoney.Droid.Services
{
    public class ViewModelNavigationService : IViewModelNavigationService
    {
        private readonly ICurrentActivity _currentActivity;

        private IDictionary<Type, Type> _keys;

        public ViewModelNavigationService(ICurrentActivity currentActivity)
        {
            _currentActivity = currentActivity;

            _keys = new Dictionary<Type, Type>
            {
                { typeof(LoginViewModel), typeof(LoginActivity) },
                { typeof(HomeViewModel), typeof(HomeActivity) }
            };
        }

        public string CurrentPageKey => string.Empty;

        public void GoBack()
        {
        }

        public void NavigateTo(string pageKey)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            throw new NotImplementedException();
        }

        public void ShowViewModel<TViewModel>()
        {
            var activityType = _keys[typeof(TViewModel)];

            _currentActivity.Activity.StartActivity(activityType);
        }
    }
}