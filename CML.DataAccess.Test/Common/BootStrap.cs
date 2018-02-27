using Autofac;
using CML.DataAccess.RegisterExtension;
using CML.Lib.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Test.Common
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：BootStrap.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BootStrap
    /// 创建标识：cml 2018/2/27 15:48:47
    /// </summary>
    public static class BootStrap
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();
            ContainerManager.UseAutofacContainer(builder)
                          //   .RegisterAssemblyTypes(repositoryAssembly, m => m.Namespace != null && m.Namespace.StartsWith("InternalControl.Repository.Implement") && m.Name.EndsWith("Repository"), lifeStyle: LifeStyle.PerLifetimeScope)
                          //  .RegisterAssemblyTypes(domainServiceAssembly, m => m.Namespace != null && m.Namespace.StartsWith("InternalControl.DomainService.Implement") && m.Name.EndsWith("DomainService"), lifeStyle: LifeStyle.PerLifetimeScope)
                          //   .RegisterAssemblyTypes(cacheAssembly, m => m.Namespace != null && m.Namespace.StartsWith("InternalControl.Cache.Implement") && m.Name.EndsWith("Cache"), lifeStyle: LifeStyle.PerLifetimeScope)
                          //   .RegisterAssemblyTypes(userApplicationAssembly, m => m.Namespace != null && m.Namespace.StartsWith("InternalControl.Application.Implement") && m.Name.EndsWith("Application"), lifeStyle: LifeStyle.PerLifetimeScope)
                          //  .RegisterAssemblyTypes(unitOfWorkAssembly, m => m.Namespace != null && m.Namespace.StartsWith("InternalControl.UnitOfWork.Implement") && m.Name.EndsWith("UnitOfWork"), lifeStyle: LifeStyle.PerLifetimeScope)
                          //  .RegisterType<IPermissionChecker, BasePermissionChecker>(lifeStyle: LifeStyle.PerLifetimeScope)
                          // .RegisterType<ILoginCheck, BaseLoginChecker>(lifeStyle: LifeStyle.PerLifetimeScope)
                          // .RegisterType<ILoginCheck, SSOLoginChecker>(lifeStyle: LifeStyle.PerLifetimeScope)
                          .UseDataAccess();
        }
    }
}
