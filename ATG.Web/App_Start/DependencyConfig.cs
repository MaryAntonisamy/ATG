using ATG.Data.Models;
using ATG.Repositories;
using ATG.Repositories.Contracts;
using ATG.Services;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATG.Web.App_Start
{
    public class DependencyConfig
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();
            // Register Services
            
            // Register EF database contexts
            builder.RegisterType<ApplicationDbContext>().InstancePerDependency();
            builder.RegisterType<FailoverContext>().InstancePerDependency();
            builder.RegisterType<ArchiveContext>().InstancePerDependency();

            // Register repositories
            builder.RegisterGeneric(typeof(GenericRepository<,>)).As(typeof(IGenericRepository<,>)).InstancePerDependency();

            builder.RegisterType<ArchiveLotRepository>().As<IArchiveLotRepository>().InstancePerDependency();
            builder.RegisterType<FailoverLotRepository>().As<IFailoverLotRepository>().InstancePerDependency();
            builder.RegisterType<LotRepository>().As<ILotRepository>().InstancePerDependency();

            builder.RegisterType<LotService>().As<ILotService>();

            ////builder.RegisterGeneric(typeof(GenericRepository<ApplicationDbContext,Lot>)).As(typeof(IGenericRepository<>)).InstancePerDependency();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        //public static void Init()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterControllers(Assembly.GetExecutingAssembly());
        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        //    builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

        //    builder.RegisterAssemblyTypes(typeof(CourseRepository).Assembly)
        //           .Where(t => t.Name.EndsWith("Repository"))
        //           .AsImplementedInterfaces()
        //           .InstancePerRequest();

        //    builder.RegisterAssemblyTypes(typeof(CourseService).Assembly)
        //           .Where(t => t.Name.EndsWith("Service"))
        //           .AsImplementedInterfaces()
        //           .InstancePerRequest();

        //    builder.RegisterFilterProvider();
        //    var container = builder.Build();
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        //}
    }
}