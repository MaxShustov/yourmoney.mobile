using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private readonly ISettingService _settingService;
        private readonly IViewModelNavigationService _viewModelNavigationService;

        public SplashViewModel(ISettingService settingService, IViewModelNavigationService viewModelNavigationService)
        {
            _settingService = settingService;
            _viewModelNavigationService = viewModelNavigationService;
        }

        public bool IsAuthorized => !string.IsNullOrEmpty(_settingService.Token);

        public void ShowFirstViewModel()
        {
            _viewModelNavigationService.ShowViewModel<ReactiveLoginViewModel>();
        }
    }
}