using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CML.AspNetCore.Authorization;
using CML.AspNetCore.Extensions;
using CML.Lib.Authorization;
using CML.Lib.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CML.AspNetCore.Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc(options =>
        //    {
        //        options.Filters.Add(typeof(ApiAuthorizeFilter));
        //    }
        //    );
        //}
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ApiAuthorizeFilter));
            }
            );
          //  services.AddAspectCoreContainer();
            services.AddDynamicProxy();
            var builder = new ContainerBuilder();
            //   builder.Populate(services);
            ContainerManager.UseAutofacContainer(builder)
                .RegisterType<IAuthorizationHelper, AuthorizationHelper>(lifeStyle: LifeStyle.PerLifetimeScope)
            .RegisterType<ILoginChecker, NullLoginChecker>(lifeStyle: LifeStyle.PerLifetimeScope)
            .RegisterType<IPermissionChecker, NullPermissionChecker>(lifeStyle: LifeStyle.PerLifetimeScope);

            //    var container = builder.Build();
            return ContainerManager.RegisterProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseErrorLog();

        }
    }
}
