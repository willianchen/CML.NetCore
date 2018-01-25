using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Dependency.AutoFac
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AutofacScopeContainer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AutofacScopeContainer
    /// 创建标识：cml 2018/1/25 14:31:11
    /// </summary>
    public class AutofacScopeContainer : IIocScope
    {
        private readonly ILifetimeScope _lifeTimeScope;

        public AutofacScopeContainer(ILifetimeScope lifeTimeScope)
        {
            _lifeTimeScope = lifeTimeScope;
        }


        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>注册的服务类型</returns>
        public TService Resolve<TService>() 
        {
            return _lifeTimeScope.Resolve<TService>();
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns>注册的服务类型</returns>
        public object Resolve(Type serviceType)
        {
            return _lifeTimeScope.Resolve(serviceType);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="instance">服务类型默认实例</param>
        /// <returns>成功 则返回true</returns>
        public bool TryResolve<TService>(out TService instance) 
        {
            return _lifeTimeScope.TryResolve(out instance);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance"></param>
        /// <returns>成功 则返回true</returns>
        public bool TryResolve(Type serviceType, out object instance)
        {
            return _lifeTimeScope.TryResolve(serviceType, out instance);
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="serviceName">服务名字</param>
        /// <returns>服务类型</returns>
        public TService ResolveNamed<TService>(string serviceName) 
        {
            return _lifeTimeScope.ResolveNamed<TService>(serviceName);
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceName">服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <returns>服务类型</returns>
        public object ResolveNamed(string serviceName, Type serviceType)
        {
            return _lifeTimeScope.ResolveNamed(serviceName, serviceType);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceName">服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance">默认实例</param>
        /// <returns>成功 则返回true</returns>
        public bool TryResolveNamed(string serviceName, Type serviceType, out object instance)
        {
            return _lifeTimeScope.TryResolveNamed(serviceName, serviceType, out instance);
        }

        public void Dispose()
        {
            _lifeTimeScope?.Dispose();
        }
    }
}