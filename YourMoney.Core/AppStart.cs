using GalaSoft.MvvmLight.Ioc;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.ApiClients.Implementation;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.Services.Implementation;
using YourMoney.Core.ViewModels;

namespace YourMoney.Core
{
    public class AppStart
    {
        public static void Initialize()
        {
            SimpleIoc.Default.Register<ISettings>(() => CrossSettings.Current);

            SimpleIoc.Default.Register<IApiContext, ApiContext>();
            SimpleIoc.Default.Register<IUserApiClient, UserApiClient>();
            SimpleIoc.Default.Register<ITransactionApiClient, TransactionApiClient>();
            SimpleIoc.Default.Register<IUserService, UserService>();
            SimpleIoc.Default.Register<ITransactionService, TransactionService>();
            SimpleIoc.Default.Register<ISettingService, SettingService>();

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<AddIncomeTransactionViewModel>();
            SimpleIoc.Default.Register<SplashViewModel>();
        }
    }
}