using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Services.Infrastructure;

namespace Cinema
{
    public class DependencyResolverConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();            
            
            builder.RegisterType<ApplicationDbContext>()
                .AsSelf()
                .InstancePerRequest();
            
            builder
                .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => x.FullName.StartsWith("CinemaSchedule.Services"))
                .Where(x => x.Name.EndsWith("Service"))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // регистрация конфигов Automapper
            builder
                .RegisterInstance(AutomapperConfig.CreateMapping())
                .As<MapperConfiguration>()
                .ExternallyOwned();

            builder
                .Register(c => c.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>()
                .SingleInstance();


            // MVC Dependency resolver
            builder.RegisterControllers(typeof(Cinema.MvcApplication).Assembly);
            var container = builder.Build();

            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}