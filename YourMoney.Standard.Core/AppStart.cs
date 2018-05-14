using System;
using System.Reflection;
using Acr.UserDialogs;
using Autofac;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using ReactiveUI;
using YourMoney.Standard.Core.Api;
using YourMoney.Standard.Core.Observers;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core.Api.Interfaces;
using System.Net.Http;

namespace YourMoney.Standard.Core
{
    public class AppStart
    {
        public static IContainer Container { get; set; }

        public static void Initialize(Action<ContainerBuilder> registerPlatformDependencies = null)
        {
            RxApp.DefaultExceptionHandler = new ExceptionObserver();

            var builder = new ContainerBuilder();

            registerPlatformDependencies?.Invoke(builder);
            RegisterDependencies(builder);

            Container = builder.Build();
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            var assembly = typeof(AppStart).GetTypeInfo().Assembly;

            builder.Register(c => CrossSettings.Current).As<ISettings>();
            builder.Register(c => UserDialogs.Instance).As<IUserDialogs>();

            builder.Register(c => HttpClientFactory.GetHttpClient(c.Resolve<ISettingService>()))
                .SingleInstance();

            builder.Register(c => RestApiFactory.GetApiClient<IUsersApi>(c.Resolve<HttpClient>()));
            builder.Register(c => RestApiFactory.GetApiClient<ICategoriesApi>(c.Resolve<HttpClient>()));
            builder.Register(c => RestApiFactory.GetApiClient<ITransactionsApi>(c.Resolve<HttpClient>()));

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .AsSelf()
                .SingleInstance();
        }
    }
}