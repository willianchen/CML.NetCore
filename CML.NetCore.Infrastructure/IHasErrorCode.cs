using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IHasErrorCode.cs
    /// 类属性：接口
    /// 类功能描述：错误码接口
    /// 创建标识：cml 2018/4/9 16:29:54
    /// </summary>
    public interface IHasErrorCode
    {
        int Code { get; set; }
    }
}
