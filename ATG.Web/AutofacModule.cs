using ATG.Data.Models;
using ATG.Repositories;
using ATG.Repositories.Contracts;
using ATG.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATG.Web
{
    public class AutofacModule :Module
    {
        public static IContainer Container { get; set; }
        public static void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the `UseServiceProviderFactory(new AutofacServiceProviderFactory())` that happens in Program and registers Autofac
            // as the service provider.
            builder.RegisterType<LotService>().As<ILotService>();
            builder.RegisterType<ApplicationDbContext>().InstancePerDependency();
            builder.RegisterType<FailoverContext>().InstancePerDependency();
            builder.RegisterType<ArchiveContext>().InstancePerDependency();

            // Register repositories
            builder.RegisterGeneric(typeof(GenericRepository<,>)).As(typeof(IGenericRepository<,>)).InstancePerDependency();
            builder.RegisterType<ArchiveLotRepository>().As<IArchiveLotRepository>().InstancePerDependency();
            builder.RegisterType<FailoverLotRepository>().As<IFailoverLotRepository>().InstancePerDependency();
            builder.RegisterType<FailoverRepository>().As<IFailoverRepository>().InstancePerDependency();
            builder.RegisterType<LotRepository>().As<ILotRepository>().InstancePerDependency();
            //builder.RegisterType<Logger>().As<ILogger>();

            

            Container = builder.Build();
        }   

    }
}
