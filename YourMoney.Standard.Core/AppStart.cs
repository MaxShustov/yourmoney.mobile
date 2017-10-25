using System;
using System.Reflection;
using Acr.UserDialogs;
using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using ReactiveUI;
using YourMoney.Standard.Core.Api;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Entities;
using YourMoney.Standard.Core.Observers;
using YourMoney.Standard.Core.Repositories;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core.Services.Implementation;

namespace YourMoney.Standard.Core
{
    public class AppStart
    {
        public static IContainer Container { get; set; }

        public static void Initialize(Action<ContainerBuilder> registerPlatformDependencies = null)
        {
            RxApp.DefaultExceptionHandler = new ExceptionObserver();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TransactionModel, Transaction>();
            });

            var builder = new ContainerBuilder();

            registerPlatformDependencies?.Invoke(builder);
            RegisterDependencies(builder);

            Container = builder.Build();

            var context = Container.Resolve<TransactionsDbContext>();
            
            context.Database.Migrate();
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            var assembly = typeof(AppStart).GetTypeInfo().Assembly;

            builder.Register(c => CrossSettings.Current).As<ISettings>();
            builder.Register(c => UserDialogs.Instance).As<IUserDialogs>();

            builder.Register(c => Mapper.Instance).As<IMapper>();

            builder.RegisterType<TransactionsDbContext>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterGeneric(typeof(EntitySyncService<,>))
                .As(typeof(IEntitySyncService<,>))
                .InstancePerDependency();

            builder.Register(c => HttpClientFactory.GetHttpClient(c.Resolve<ISettingService>()))
                .SingleInstance();
            
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("ApiClient"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .AsSelf()
                .SingleInstance();
        }
    }
}