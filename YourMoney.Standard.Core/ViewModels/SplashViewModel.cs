using Autofac;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private readonly ISettingService _settingService;
        private readonly IPageRouter<SplashViewModel> _pageRouter;

        public SplashViewModel(ISettingService settingService, IPageRouter<SplashViewModel> pageRouter)
        {
            _settingService = settingService;
            _pageRouter = pageRouter;
        }

        public bool IsAuthorized => !string.IsNullOrEmpty(_settingService.Token);

        public void ShowFirstViewModel()
        {
            _pageRouter.NavigateTo<ReactiveLoginViewModel>();
        }
    }
}