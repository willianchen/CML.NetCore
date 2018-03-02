using System;
using System.Reflection;
using Autofac;
using CML.DataAccess.RegisterExtension;
using CML.Lib.Dependency;
using KjNet.SqlDoc.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KjNet.SqlDoc.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
          //  var repositoryAssembly = Assembly.Load("KjNet.SqlDoc.Repository");
           // var domainServiceAssembly = Assembly.Load("KjNet.SqlDoc.DomainService");
           // var cacheAssembly = Assembly.Load("KjNet.SqlDoc.Cache");
            var userApplicationAssembly = Assembly.Load("KjNet.SqlDoc.Application");

            var builder = new ContainerBuilder();
            //   builder.Populate(services);
            ContainerManager.UseAutofacContainer(builder)
                        //   .RegisterAssemblyTypes(repositoryAssembly, m => m.Namespace != null && m.Namespace.StartsWith("KjNet.SqlDoc.Repository.Implement") && m.Name.EndsWith("Repository"), lifeStyle: LifeStyle.PerLifetimeScope)
                        //  .RegisterAssemblyTypes(domainServiceAssembly, m => m.Namespace != null && m.Namespace.StartsWith("KjNet.SqlDoc.DomainService.Implement") && m.Name.EndsWith("DomainService"), lifeStyle: LifeStyle.PerLifetimeScope)
                        //   .RegisterAssemblyTypes(cacheAssembly, m => m.Namespace != null && m.Namespace.StartsWith("KjNet.SqlDoc.Cache.Implement") && m.Name.EndsWith("Cache"), lifeStyle: LifeStyle.PerLifetimeScope)
                        .RegisterAssemblyTypes(userApplicationAssembly, m => m.Namespace != null && m.Namespace.StartsWith("KjNet.SqlDoc.Application.Implement") && m.Name.EndsWith("Application"), lifeStyle: LifeStyle.PerLifetimeScope)
                     //      .RegisterAssemblyTypes(unitOfWorkAssembly, m => m.Namespace != null && m.Namespace.StartsWith("KjNet.SqlDoc.UnitOfWork.Implement") && m.Name.EndsWith("UnitOfWork"), lifeStyle: LifeStyle.PerLifetimeScope)
                     //  .RegisterType<IPermissionChecker, BasePermissionChecker>(lifeStyle: LifeStyle.PerLifetimeScope)
                     // .RegisterType<ILoginCheck, BaseLoginChecker>(lifeStyle: LifeStyle.PerLifetimeScope)
                     // .RegisterType<ILoginCheck, SSOLoginChecker>(lifeStyle: LifeStyle.PerLifetimeScope)
                     .UseDataAccess();
            //    var container = builder.Build();
            return ContainerManager.RegisterProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
