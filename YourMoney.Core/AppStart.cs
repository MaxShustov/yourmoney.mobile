using System;
using Autofac;
using YourMoney.Core.ViewModels;

namespace YourMoney.Core
{
    public class AppStart
    {
        public static IContainer Container { get; set; }

        public static void Initialize(Action<ContainerBuilder> registerPlatformDependencies = null)
        {
            var builder = new ContainerBuilder();

            registerPlatformDependencies?.Invoke(builder);
            RegisterDependencies(builder);

            Container = builder.Build();

            //SimpleIoc.Default.Register<ISettings>(() => CrossSettings.Current);

            //SimpleIoc.Default.Register<IApiContext, ApiContext>();
            //SimpleIoc.Default.Register<IUserApiClient, UserApiClient>();
            //SimpleIoc.Default.Register<ITransactionApiClient, TransactionApiClient>();
            //SimpleIoc.Default.Register<IUserService, UserService>();
            //SimpleIoc.Default.Register<ITransactionService, TransactionService>();
            //SimpleIoc.Default.Register<ISettingService, SettingService>();

            //SimpleIoc.Default.Register<LoginViewModel>();
            //SimpleIoc.Default.Register<RegisterViewModel>();
            //SimpleIoc.Default.Register<HomeViewModel>();
            //SimpleIoc.Default.Register<AddIncomeTransactionViewModel>();
            //SimpleIoc.Default.Register<SplashViewModel>();
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<ReactiveLoginViewModel>().SingleInstance();
        }
    }
}