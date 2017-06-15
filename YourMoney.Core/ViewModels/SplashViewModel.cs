using GalaSoft.MvvmLight;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class SplashViewModel : ViewModelBase, IViewModel
    {
        private readonly ISettingService _settingService;
        private readonly IViewModelNavigationService _viewModelNavigationService;

        public SplashViewModel(ISettingService settingService, IViewModelNavigationService viewModelNavigationService)
        {
            _settingService = settingService;
            _viewModelNavigationService = viewModelNavigationService;
        }

        public bool IsAuthorized => !string.IsNullOrEmpty(_settingService.UserId);

        public void ShowFirstViewModel()
        {
            _viewModelNavigationService.ShowViewModel<LoginViewModel>();
        }

        public void BeforeBack()
        {
        }

        public void OnBack()
        {
        }
    }
}