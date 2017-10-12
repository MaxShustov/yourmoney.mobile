using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Autofac;
using YourMoney.Core;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.UWP.Services
{
    public class ViewModelNavigationService : IViewModelNavigationService
    {
        private readonly IDictionary<Type, Type> _keys;

        public ViewModelNavigationService()
        {
            _keys = GetNavigationMap();
        }

        public void ShowViewModel<TViewModel>()
        {
            var viewModelType = typeof(TViewModel);
            var pageType = _keys[viewModelType];

            RootFrame.Navigate(pageType);
        }

        public void GoBack()
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
            }
        }

        private Frame RootFrame => Window.Current.Content as Frame;

        private IDictionary<Type, Type> GetNavigationMap()
        {
            var viewModelInterface = typeof(IViewModel);
            var viewinterface = typeof(IViewFor<>);

            var viewModelTypes = typeof(IViewModel).GetTypeInfo().Assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i == viewModelInterface));

            var viewTypes = this.GetType().GetTypeInfo().Assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.GenericTypeArguments.Any() && i.GetGenericTypeDefinition() == viewinterface));

            var typeMap = viewModelTypes.ToDictionary(v => v, v =>
            {
                var fullViewInterface = viewinterface.MakeGenericType(v);

                return viewTypes.SingleOrDefault(vt => vt.GetInterfaces().Any(i => i == fullViewInterface));
            })
            .Where(kv => kv.Value != null)
            .ToDictionary(kv => kv.Key, kv => kv.Value);

            return typeMap;
        }

        public void ShowViewModel<TViewModel>(object navigationParameter)
        {
            var viewModelType = typeof(TViewModel);
            var pageType = _keys[viewModelType];

            var viewModel = (IViewModel)AppStart.Container.Resolve(viewModelType);
            viewModel.InitWithParam(navigationParameter);

            RootFrame.Navigate(pageType);
        }
    }
}