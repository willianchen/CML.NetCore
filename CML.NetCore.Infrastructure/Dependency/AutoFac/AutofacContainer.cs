using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using CML.Lib.Utils;

namespace CML.Lib.Dependency.AutoFac
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AutofacContainer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Auto容器
    /// 创建标识：cml 2017/11/17 16:02:17
    /// </summary>
    public class AutofacContainer : IIocContainer
    {
        private IContainer _container;
        private ContainerBuilder _builder;

        public AutofacContainer()
        {
            _builder = new ContainerBuilder();
            _container = null;
        }

        public AutofacContainer(ContainerBuilder builder)
        {
            _builder = builder ?? new ContainerBuilder();
            _container = null;
        }

        public IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    lock (this)
                    {
                        if (_container == null)
                        {
                            _container = _builder.Build();
                        }
                    }
                }
                return _container;
            }
        }

        public IIocScope BeginScope()
        {
            return new AutofacScopeContainer(_container.BeginLifetimeScope());
        }

        #region 支付注册

        /// <summary>
        /// 判断是否注册
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public bool IsRegistered(Type serviceType)
        {
            return Container.IsRegistered(serviceType);
        }

        public bool IsRegistered<TService>()
        {
            return Container.IsRegistered<TService>();
        }

        public bool IsRegisteredWithName(string serviceName, Type serviceType)
        {
            return Container.IsRegisteredWithName(serviceName, serviceType);
        }

        public bool IsRegisteredWithName<TService>(string serviceName)
        {
            return Container.IsRegisteredWithName<TService>(serviceName);
        }

        #endregion

        #region 注册

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="implementationType">实例类型</param>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterType(Type implementationType, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterType(implementationType).AsSelf();
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                registrationBuilder.Named(serviceName, implementationType);
            }
            registrationBuilder.SetLifeStyle(lifeStyle);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="implementationType">实例类型</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterType(Type implementationType, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterType(implementationType).AsSelf();
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                registrationBuilder.Named(serviceName, implementationType);
            }
            registrationBuilder.InterceptedBy(interceptTypeList).EnableInterfaceInterceptors().SetLifeStyle(lifeStyle);
        }

        public void RegisterType<T>(string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterType<T>().AsSelf();
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                registrationBuilder.Named<T>(serviceName);
            }
            registrationBuilder.SetLifeStyle(lifeStyle);
        }

        public void RegisterType<T>(Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterType<T>().AsSelf();
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                registrationBuilder.Named<T>(serviceName);
            }
            registrationBuilder.InterceptedBy(interceptTypeList).EnableInterfaceInterceptors().SetLifeStyle(lifeStyle);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实例类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="life">生命周期</param>
        public void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterType(implementationType).As(serviceType);
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                registrationBuilder.Named(serviceName, implementationType);
            }
            registrationBuilder.SetLifeStyle(lifeStyle);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实例类型</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterType(Type serviceType, Type implementationType, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterType(implementationType).As(serviceType);
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                registrationBuilder.Named(serviceName, implementationType);
            }
            registrationBuilder.InterceptedBy(interceptTypeList).EnableInterfaceInterceptors().SetLifeStyle(lifeStyle);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterType<TService, TImplementer>(string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterType<TImplementer>().As<TService>();
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                registrationBuilder.Named<TService>(serviceName);
            }
            registrationBuilder.SetLifeStyle(lifeStyle);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterType<TService, TImplementer>(Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterType<TImplementer>().As<TService>();
            if (!string.IsNullOrWhiteSpace(serviceName))
            {
                registrationBuilder.Named<TService>(serviceName);
            }
            registrationBuilder.InterceptedBy(interceptTypeList).EnableInterfaceInterceptors().SetLifeStyle(lifeStyle);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="instance">实例值</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterInstance(instance).As<TService>();
            if (serviceName != null)
            {
                registrationBuilder.Named<TService>(serviceName);
            }
            registrationBuilder.SetLifeStyle(lifeStyle);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="instance">实例值</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterInstance<TService, TImplementer>(TImplementer instance, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            var builder = _builder;
            var registrationBuilder = builder.RegisterInstance(instance).As<TService>();
            if (serviceName != null)
            {
                registrationBuilder.Named<TService>(serviceName);
            }
            registrationBuilder.InterceptedBy(interceptTypeList).EnableInterfaceInterceptors().SetLifeStyle(lifeStyle);
        }

        /// <summary>
        /// 根据程序集注册
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterAssemblyTypes(Assembly assemblies, Func<Type, bool> predicate = null, LifeStyle lifeStyle = LifeStyle.PerLifetimeScope)
        {
            if (assemblies != null)
            {
                var builder = _builder;
                var registrationBuilder = builder.RegisterAssemblyTypes(assemblies);
                if (predicate != null)
                {
                    registrationBuilder.Where(predicate);
                }
                registrationBuilder.AsImplementedInterfaces().SetLifeStyle(lifeStyle);
            }
        }

        /// <summary>
        /// 根据程序集注册
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="lifeStyle">生命周期</param>
        public void RegisterAssemblyTypes(Assembly assemblies, Type[] interceptTypeList, Func<Type, bool> predicate = null, LifeStyle lifeStyle = LifeStyle.PerLifetimeScope)
        {
            if (assemblies != null)
            {
                var builder = _builder;
                var registrationBuilder = builder.RegisterAssemblyTypes(assemblies);
                if (predicate != null)
                {
                    registrationBuilder.Where(predicate);
                }
                registrationBuilder.AsImplementedInterfaces().InterceptedBy(interceptTypeList).EnableInterfaceInterceptors().SetLifeStyle(lifeStyle);
            }
        }

        #endregion 注册

        #region 实例化

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            if (IsExistSerivceContext())
            {
                return WebUtil.HttpContext.RequestServices.GetService(type);
            }
            return Container.Resolve(type);
        }

        public T ResolveNamed<T>(string serviceName)
        {
            if (IsExistSerivceContext())
            {
                return WebUtil.HttpContext.RequestServices.GetService<IComponentContext>().ResolveNamed<T>(serviceName);
            }
            return Container.ResolveNamed<T>(serviceName);
        }

        public object ResolveNamed(string serviceName, Type serviceType)
        {
            if (IsExistSerivceContext())
            {
                return WebUtil.HttpContext.RequestServices.GetService<IComponentContext>().ResolveNamed(serviceName, serviceType);
            }
            return Container.ResolveNamed(serviceName, serviceType);
        }

        public bool TryResolve<T>(out T instance)
        {
            if (IsExistSerivceContext())
            {
                return WebUtil.HttpContext.RequestServices.GetService<IComponentContext>().TryResolve(out instance);
            }
            return Container.TryResolve<T>(out instance);
        }

        public bool TryResolve(Type serviceType, out object instance)
        {
            if (IsExistSerivceContext())
            {
                return WebUtil.HttpContext.RequestServices.GetService<IComponentContext>().TryResolve(serviceType, out instance);
            }
            return Container.TryResolve(serviceType, out instance);
        }

        public bool TryResolveNamed(string serviceName, Type serviceType, out object instance)
        {
            if (IsExistSerivceContext())
            {
                return WebUtil.HttpContext.RequestServices.GetService<IComponentContext>().TryResolveNamed(serviceName, serviceType, out instance);
            }

            return Container.TryResolveNamed(serviceName, serviceType, out instance);
        }

        #endregion

        /// <summary>
        /// 是否存在上下文
        /// </summary>
        /// <returns></returns>
        private bool IsExistSerivceContext()
        {
            return WebUtil.HttpContext?.RequestServices != null;
        }

        public IServiceProvider RegisterProvider(IServiceCollection services)
        {
            if (services != null)
                _builder.Populate(services);
            return new AutofacServiceProvider(Container);
        }

    }
}
