using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Android.Content;
using Plugin.CurrentActivity;
using ReactiveUI;
using YourMoney.Droid.Attributes;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core.ViewModels.Abstract;

namespace YourMoney.Droid.Services
{
    public class ViewModelNavigationService : IViewModelNavigationService
    {
        private readonly ICurrentActivity _currentActivity;
        private readonly IDictionary<Type, Type> _navigationMap;

        public ViewModelNavigationService(ICurrentActivity currentActivity)
        {
            _currentActivity = currentActivity;

            _navigationMap = GetNavigationMap();
        }

        public void ShowViewModel<TViewModel>(object navigationParameter)
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            _currentActivity.Activity.Finish();
        }

        public void ShowViewModel<TViewModel>()
        {
            var activityType = _navigationMap[typeof(TViewModel)];
            var navigationAttribute = activityType.GetCustomAttributes<NavigationAttribute>().FirstOrDefault();

            var intent = new Intent(_currentActivity.Activity, activityType);

            if (navigationAttribute != null && !navigationAttribute.History)
            {
                intent.AddFlags(ActivityFlags.NoHistory);
            }

            _currentActivity.Activity.StartActivity(intent);
        }

        private IDictionary<Type, Type> GetNavigationMap()
        {
            var viewModelInterface = typeof(IViewModel);
            var viewinterface = typeof(IViewFor<>);

            var viewModelTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterfaces().Any(i => i == viewModelInterface));

            var viewTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == viewinterface));

            var typeMap = viewModelTypes.ToDictionary(v => v, v =>
            {
                var fullViewInterface = viewinterface.MakeGenericType(v);

                return viewTypes.SingleOrDefault(vt => vt.GetInterfaces().Any(i => i == fullViewInterface));
            })
            .Where(kv => kv.Value != null)
            .ToDictionary(kv => kv.Key, kv => kv.Value);

            return typeMap;
        }
    }
}