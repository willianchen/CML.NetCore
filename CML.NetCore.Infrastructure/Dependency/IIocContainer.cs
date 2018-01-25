using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Dependency
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IIocContainer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Ioc容器接口
    /// 创建标识：cml 2017/11/17 15:40:16
    /// </summary>
    public interface IIocContainer : IIocRegister, IIocResolver
    {
        /// <summary>
        /// 判断是否注册过类型
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        bool IsRegistered(Type serviceType);

        /// <summary>
        /// 判断是否注册过类型
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        bool IsRegistered<TService>();

        /// <summary>
        /// 判断是否注册类型
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        bool IsRegisteredWithName(string serviceName, Type serviceType);

        /// <summary>
        /// 判断是否注册过类型
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        bool IsRegisteredWithName<TService>(string serviceName);

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        IServiceProvider RegisterProvider(IServiceCollection services);

        /// <summary>
        /// 作用域开始
        /// </summary>
        IIocScope BeginScope();
    }
}
