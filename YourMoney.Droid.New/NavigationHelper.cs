using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ReactiveUI;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core.ViewModels.Abstract;

namespace YourMoney.Droid.New
{
    public class NavigationHelper: INavigationHelper
    {
        public NavigationHelper()
        {
            var viewModelInterface = typeof(IViewModel);
            var viewinterface = typeof(IViewFor<>);

            var viewModelTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterfaces().Any(i => i == viewModelInterface));

            var viewTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == viewinterface));

            NavigationMap = viewModelTypes.ToDictionary(v => v, v =>
                {
                    var fullViewInterface = viewinterface.MakeGenericType(v);

                    return viewTypes.SingleOrDefault(vt => vt.GetInterfaces().Any(i => i == fullViewInterface));
                })
                .Where(kv => kv.Value != null)
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public IDictionary<Type, Type> NavigationMap { get; }
    }
}