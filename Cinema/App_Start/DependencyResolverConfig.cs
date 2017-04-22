using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Cinema.App_Start
{
    public class DependencyResolverConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            builder
                .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => x.FullName.StartsWith("Cinma.Services"))
                .Where(x => x.Name.EndsWith("DataService"))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // MVC Dependency resolver
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}