using Castle.DynamicProxy;

namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BaseIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：基础AOP类
    /// 创建标识：yjq 2017/7/15 14:33:04
    /// </summary>
    public abstract class BaseIntercept : IInterceptor
    {
        public abstract void Intercept(IInvocation invocation);
    }
}