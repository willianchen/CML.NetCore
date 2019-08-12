using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CML.Lib.HystrixCore
{
    public static class HystrixCommandExtensions
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="asm"></param>
        /// <param name="services"></param>
        public static void RegisterHystrixServices(this IServiceCollection services, Assembly asm)
        {
            //遍历程序集中的所有 public 类型
            foreach (Type type in asm.GetExportedTypes())
            {
                //判断类中是否有标注了 CustomInterceptorAttribute 的方法
                bool hasCustomInterceptorAttr = type.GetMethods()
                .Any(m => m.GetCustomAttribute(typeof(HystrixCommandAttribute)) != null);
                if (hasCustomInterceptorAttr)
                {
                    services.AddSingleton(type);
                }
            }
        }

        /// <summary>
        /// 注册动态Aop
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider BuildDynamicProxyService(this IServiceCollection services)
        {
            return services.BuildDynamicProxyServiceProvider();
        }
    }
}
