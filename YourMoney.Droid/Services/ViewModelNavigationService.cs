using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Plugin.CurrentActivity;
using ReactiveUI;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.Droid.Services
{
    public class ViewModelNavigationService : IViewModelNavigationService
    {
        private readonly ICurrentActivity _currentActivity;

        private IDictionary<Type, Type> _keys;

        public ViewModelNavigationService(ICurrentActivity currentActivity)
        {
            _currentActivity = currentActivity;

            _keys = GetNavigationMap();
            //_keys = new Dictionary<Type, Type>
            //{
            //    { typeof(LoginViewModel), typeof(LoginActivity) },
            //    { typeof(HomeViewModel), typeof(HomeActivity) },
            //    { typeof(AddIncomeTransactionViewModel), typeof(AddIncomeActivity) },
            //    { typeof(RegisterViewModel), typeof(RegistrationActivity) }
            //};
        }

        public string CurrentPageKey => string.Empty;

        public void GoBack()
        {
            _currentActivity.Activity.Finish();
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