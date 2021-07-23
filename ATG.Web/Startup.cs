//using ATG.Data.Models;
//using ATG.Repositories;
//using ATG.Repositories.Contracts;
//using ATG.Services;
//using ATG.Web.App_Start;
//using Autofac;
//using Autofac.Integration.Mvc;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace ATG.Web
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllers();
//            services.AddScoped<ILotService, LotService>();

//            //services.AddScoped<ILotRepository, LotRepository>();
//            services.AddDbContext<ApplicationDbContext>(options =>
//       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

//            services.AddDbContext<FailoverContext>(options =>
//                options.UseSqlServer(Configuration.GetConnectionString("FailoverConnection")));
//            services.AddDbContext<ArchiveContext>(options =>
//                options.UseSqlServer(Configuration.GetConnectionString("ArchiveConnection")));

//            var builder = new ContainerBuilder();
//            DependencyConfig.Init(builder);

//        }
//        public void ConfigureContainer(ContainerBuilder builder)
//        {
//            //  DependencyConfig.Init(builder);

//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            app.UseRouting();
//            app.UseEndpoints(builder => builder.MapControllers());
//        }
//    }
//}
using System;
using System.Linq;
using ATG.Data.Models;
using ATG.Repositories;
using ATG.Repositories.Contracts;
using ATG.Services;
using ATG.Web;
using ATG.Web.App_Start;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Owin;

namespace ATG.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddScoped<ILotService, LotService>();

            //services.AddScoped<ILotRepository, LotRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<FailoverContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FailoverConnection")));
            services.AddDbContext<ArchiveContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ArchiveConnection")));
            

            // Register EF database contexts
            services.AddDbContext<ApplicationDbContext>();
            services.AddDbContext<FailoverContext>();
            services.AddDbContext<ArchiveContext>();

            // Register repositories
           // services.AddScoped(typeof(IGenericRepository<,>),(typeof(GenericRepository<,>)));
            services.AddScoped<IArchiveLotRepository, ArchiveLotRepository>();
            services.AddScoped<IFailoverLotRepository, FailoverLotRepository>();
            services.AddScoped<IFailoverRepository, FailoverRepository>();
            services.AddScoped<ILotRepository, LotRepository>();
            services.AddScoped<ILotService, LotService>();

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DependencyConfig.Init();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
