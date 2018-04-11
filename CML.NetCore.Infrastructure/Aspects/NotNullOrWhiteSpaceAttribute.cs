using AspectCore.DynamicProxy.Parameters;
using CML.Lib.Aspects.Base;
using CML.Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Aspects
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：NotEmptyAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：验证不能为空
    /// 创建标识：cml 2018/4/11 14:53:36
    /// </summary>
    public class NotNullOrWhiteSpaceAttribute : ParameterInterceptorBase
    {
        /// <summary>
        /// 执行
        /// </summary>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (string.IsNullOrWhiteSpace(context.Parameter.Value.ToSafeString()))
                throw new ArgumentNullException(context.Parameter.Name);
            return next(context);
        }
    }
}
