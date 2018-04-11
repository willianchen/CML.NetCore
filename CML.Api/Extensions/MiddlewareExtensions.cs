using CML.AspNetCore.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.AspNetCore.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：MiddlewareExtensions.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：中间件扩展
    /// 创建标识：cml 2018/4/10 10:52:54
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册错误日志管道
        /// </summary>
        /// <param name="builder">应用程序生成器</param>
        public static IApplicationBuilder UseErrorLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLogMiddleware>();
        }
    }
}