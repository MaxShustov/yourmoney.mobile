using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.ViewModels;
using YourMoney.Core.ViewModels.Abstract;
using YourMoney.UWP.Pages;

namespace YourMoney.UWP.Services
{
    public class ViewModelNavigationService : IViewModelNavigationService
    {
        private readonly IDictionary<Type, Type> _keys;

        private string _currentPageKey;

        public ViewModelNavigationService()
        {
            _keys = new Dictionary<Type, Type>
            {
                { typeof(LoginViewModel), typeof(LoginPage) },
                { typeof(RegisterViewModel), typeof(RegisterPage) },
                { typeof(HomeViewModel), typeof(HomePage) },
                { typeof(AddIncomeTransactionViewModel), typeof(AddTransactionPage) }
            };
        }

        public void ShowViewModel<TViewModel>()
        {
            var viewModelType = typeof(TViewModel);
            var pageType = _keys[viewModelType];

            RootFrame.Navigate(pageType);

            _currentPageKey = viewModelType.ToString();
        }

        public void GoBack()
        {
            if (RootFrame.CanGoBack)
            {
                var viewModelType = _keys.Single(p => p.Value == RootFrame.BackStack.Last().SourcePageType).Key;
                var viewModel = (IViewModel)SimpleIoc.Default.GetInstance(viewModelType);

                viewModel.Appearing();

                RootFrame.GoBack();

                viewModel.Appeared();
            }
        }

        public void NavigateTo(string pageKey)
        {
            var pageType = _keys.Single(p => p.Key.ToString() == pageKey).Value;

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