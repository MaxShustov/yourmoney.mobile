using System;
using Acr.UserDialogs;
using Autofac;
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
        public static IContainer Container { get; set; }

        public static void Initialize(Action<ContainerBuilder> registerPlatformDependencies = null)
        {
            var builder = new ContainerBuilder();

            registerPlatformDependencies?.Invoke(builder);
            RegisterDependencies(builder);

            Container = builder.Build();
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.Register(c => CrossSettings.Current).As<ISettings>();
            builder.Register(c => UserDialogs.Instance).As<IUserDialogs>();

            builder.RegisterType<ApiContext>().As<IApiContext>();
            builder.RegisterType<UserApiClient>().As<IUserApiClient>();
            builder.RegisterType<CategoriesApiClient>().As<ICategoriesApiClient>();
            builder.RegisterType<TransactionApiClient>().As<ITransactionApiClient>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<TransactionService>().As<ITransactionService>();
            builder.RegisterType<CategoriesService>().As<ICategoriesService>();
            builder.RegisterType<SettingService>().As<ISettingService>();

            builder.RegisterType<ReactiveLoginViewModel>().SingleInstance();
            builder.RegisterType<SplashViewModel>().SingleInstance();
            builder.RegisterType<ReactiveRegisterViewModel>().SingleInstance();
            builder.RegisterType<ReactiveHomeViewModel>().SingleInstance();
            builder.RegisterType<ReactiveAddIncomeTransactionViewModel>().SingleInstance();
        }
    }
}