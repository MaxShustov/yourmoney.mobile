using System;
using System.Reflection;
using Acr.UserDialogs;
using Autofac;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using ReactiveUI;
using YourMoney.Core.Observers;

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