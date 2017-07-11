using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.UWP.Services
{
    public class ViewModelNavigationService : IViewModelNavigationService
    {
        private readonly IDictionary<Type, Type> _keys;

        public ViewModelNavigationService()
        {
            _keys = new Dictionary<Type, Type>();
        }

        public void ShowViewModel<TViewModel>()
        {
            var viewModelType = typeof(TViewModel);
            var pageType = _keys[viewModelType];

            RootFrame.Navigate(pageType);
        }

        public void GoBack()
        {
        }

        private Frame RootFrame => Window.Current.Content as Frame;
    }
}