using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using CML.Lib.Dependency.AutoFac;
using Microsoft.Extensions.DependencyInjection;

namespace CML.Lib.Dependency
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ContainerManager.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ContainerManager
    /// 创建标识：cml 2018/1/23 15:46:55
    /// </summary>
    public class ContainerManager
    {
        private ContainerManager()
        {
        }

        static ContainerManager()
        {
            Instance = new ContainerManager();
        }

        public IIocContainer Container { get; private set; }

        public static ContainerManager Instance { get; private set; }

        public static ContainerManager UseAutofacContainer(ContainerBuilder builder)
        {
            return SetContainer(new AutofacContainer(builder));
        }

        private static ContainerManager SetContainer(IIocContainer container)
        {
            Instance.Container = container;
            return Instance;
        }

        #region 注册

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="implementationType">实例类型</param>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterType(Type implementationType, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            Container.RegisterType(implementationType, serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="implementationType">实例类型</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterType(Type implementationType, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            Container.RegisterType(implementationType, interceptTypeList, serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterType<T>(string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            Container.RegisterType<T>(serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterType<T>(Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            Container.RegisterType<T>(interceptTypeList, serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实例类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="life">生命周期</param>
        public ContainerManager RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            Container.RegisterType(serviceType, implementationType, serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实例类型</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterType(Type serviceType, Type implementationType, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            Container.RegisterType(serviceType, implementationType, interceptTypeList, serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterType<TService, TImplementer>(string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            Container.RegisterType<TService, TImplementer>(serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterType<TService, TImplementer>(Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            Container.RegisterType<TService, TImplementer>(interceptTypeList, serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="instance">实例值</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            Container.RegisterInstance<TService, TImplementer>(instance, serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
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
        public ContainerManager RegisterInstance<TService, TImplementer>(TImplementer instance, Type[] interceptTypeList, string serviceName = null, LifeStyle lifeStyle = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            Container.RegisterInstance<TService, TImplementer>(instance, interceptTypeList, serviceName: serviceName, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 根据程序集注册
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterAssemblyTypes(Assembly assemblies, Func<Type, bool> predicate = null, LifeStyle lifeStyle = LifeStyle.PerLifetimeScope)
        {
            Container.RegisterAssemblyTypes(assemblies, predicate: predicate, lifeStyle: lifeStyle);
            return this;
        }

        /// <summary>
        /// 根据程序集注册
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <param name="interceptTypeList">Aop类型</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="lifeStyle">生命周期</param>
        public ContainerManager RegisterAssemblyTypes(Assembly assemblies, Type[] interceptTypeList, Func<Type, bool> predicate = null, LifeStyle lifeStyle = LifeStyle.PerLifetimeScope)
        {
            Container.RegisterAssemblyTypes(assemblies, interceptTypeList, predicate: predicate, lifeStyle: lifeStyle);
            return this;
        }

        #endregion 注册

        #region 解析获取

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>注册的服务类型</returns>
        public static TService Resolve<TService>() where TService : class
        {
            return Instance.Container.Resolve<TService>();
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns>注册的服务类型</returns>
        public static object Resolve(Type serviceType)
        {
            return Instance.Container.Resolve(serviceType);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="instance">服务类型默认实例</param>
        /// <returns>成功 则返回true</returns>
        public static bool TryResolve<TService>(out TService instance) where TService : class
        {
            return Instance.Container.TryResolve(out instance);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance"></param>
        /// <returns>成功 则返回true</returns>
        public static bool TryResolve(Type serviceType, out object instance)
        {
            return Instance.Container.TryResolve(serviceType, out instance);
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="serviceName">服务名字</param>
        /// <returns>服务类型</returns>
        public static TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            return Instance.Container.ResolveNamed<TService>(serviceName);
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceName">服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <returns>服务类型</returns>
        public static object ResolveNamed(string serviceName, Type serviceType)
        {
            return Instance.Container.ResolveNamed(serviceName, serviceType);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceName">服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance">默认实例</param>
        /// <returns>成功 则返回true</returns>
        public static bool TryResolveNamed(string serviceName, Type serviceType, out object instance)
        {
            return Instance.Container.TryResolveNamed(serviceName, serviceType, out instance);
        }

        #endregion 解析获取

        #region 判断是否注册

        /// <summary>
        /// 判断是否已注册该服务
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns>true表示已注册</returns>
        public static bool IsRegistered(Type serviceType)
        {
            return Instance.Container.IsRegistered(serviceType);
        }

        /// <summary>
        /// 判断是否已注册该服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>true表示已注册</returns>
        public static bool IsRegistered<TService>()
        {
            return Instance.Container.IsRegistered<TService>();
        }

        /// <summary>
        /// 判断是否已注册该服务
        /// </summary>
        /// <param name="serviceName">注册的服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <returns>true表示已注册</returns>
        public static bool IsRegisteredWithName(string serviceName, Type serviceType)
        {
            return Instance.Container.IsRegisteredWithName(serviceName, serviceType);
        }

        /// <summary>
        /// 判断是否已注册该服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="serviceName">注册的服务名字</param>
        /// <returns>true表示已注册</returns>
        public static bool IsRegisteredWithName<TService>(string serviceName)
        {
            return Instance.Container.IsRegisteredWithName<TService>(serviceName);
        }


        #endregion 判断是否注册

        /// <summary>
        /// 开始一个作用域请求，与其它请求相互独立
        /// </summary>
        /// <returns>IIocScopeResolve</returns>
        public static IIocScope BeginLeftScope()
        {
            return Instance.Container.BeginScope();
        }

        public static IServiceProvider RegisterProvider(IServiceCollection services)
        {
            return Instance.Container.RegisterProvider(services);
        }

    }
}