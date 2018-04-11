using AspectCore.DynamicProxy.Parameters;
using CML.Lib.Aspects.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Aspects
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：NotNullAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Null拦截
    /// 创建标识：cml 2018/4/11 14:55:12
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class NotNullAttribute : ParameterInterceptorBase
    {
        /// <summary>
        /// 执行
        /// </summary>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.Value == null)
                throw new ArgumentNullException(context.Parameter.Name);
            return next(context);
        }
    }
}

