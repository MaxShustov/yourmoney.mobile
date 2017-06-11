using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.ViewModels;
using YourMoney.UWP.Pages;

namespace YourMoney.UWP.Services
{
    public class ViewModelNavigationService : IViewModelNavigationService
    {
        private readonly IDictionary<string, Type> _keys;

        private string _currentPageKey;

        public ViewModelNavigationService()
        {
            _keys = new Dictionary<string, Type>
            {
                { typeof(LoginViewModel).ToString(), typeof(LoginPage) },
                { typeof(RegisterViewModel).ToString(), typeof(RegisterPage) },
                { typeof(HomeViewModel).ToString(), typeof(HomePage) },
                { typeof(AddIncomeTransactionViewModel).ToString(), typeof(AddTransactionPage) }
            };
        }

        public void ShowViewModel<TViewModel>()
        {
            var viewModelType = typeof(TViewModel);
            var pageType = _keys[viewModelType.ToString()];

            RootFrame.Navigate(pageType);

            _currentPageKey = viewModelType.ToString();
        }

        public void GoBack()
        {
            throw new System.NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {
            var pageType = _keys[pageKey];

            RootFrame.Navigate(pageType);

            _currentPageKey = pageKey;
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            throw new System.NotImplementedException();
        }

        public string CurrentPageKey => _currentPageKey;

        private Frame RootFrame => Window.Current.Content as Frame;
    }
}