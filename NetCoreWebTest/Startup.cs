using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using NetCoreWebTest.DemoIoc;
using Microsoft.Extensions.Logging;

namespace NetCoreWebTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //    var containerBuilder = new ContainerBuilder();

        //    ContainerManager.UseAutofacContainer(containerBuilder)
        //                 .RegisterType<IDemo, Demo>(lifeStyle: LifeStyle.PerLifetimeScope);
        //    //.RegisterProvider(services);
        //    //    var container = (ContainerManager.Instance.Container as AutofacContainer).Container;

        //    return ContainerManager.Instance.RegisterProvider(services);

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
