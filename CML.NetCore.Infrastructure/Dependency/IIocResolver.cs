using System;

namespace CML.Lib.Dependency
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 解析一个类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        /// 解析一个类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 尝试解析一个类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool TryResolve<T>(out T instance);


        /// <summary>
        /// 尝试解析一个类型
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool TryResolve(Type serviceType, out object instance);

        /// <summary>
        /// 解析一个类型
        /// </summary>
        /// <typeparam name="T">解析类型</typeparam>
        /// <param name="serviceName">类型名称</param>
        /// <returns></returns>
        T ResolveNamed<T>(string serviceName);

        /// <summary>
        /// 解析一个类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceName">类型名称</param>
        /// <param name="serviceType">类型</param>
        /// <returns></returns>
         object ResolveNamed(string serviceName, Type serviceType);

        /// <summary>
        /// 尝试解析一个类型
        /// </summary>
        /// <param name="serviceName">类型名称</param>
        /// <param name="serviceType">类型</param>
        /// <param name="instance">解析实例</param>
        /// <returns></returns>
        bool TryResolveNamed(string serviceName, Type serviceType, out object instance);
    }
}
