using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Dependency
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IIocScope.cs
    /// 类属性：接口
    /// 类功能描述：作用域
    /// 创建标识：cml 2017/11/17 16:01:21
    /// </summary>
    public interface IIocScope : IIocResolver, IDisposable
    {
    }
}
