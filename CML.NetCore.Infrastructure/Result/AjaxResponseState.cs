using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Result
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AjaxResponseState.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AjaxResponseState
    /// 创建标识：cml 2018/4/9 14:48:55
    /// </summary>
    public enum AjaxResponseState
    {
        /// <summary>
        /// 失败
        /// </summary>
        Failed = 0,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,

        /// <summary>
        /// 未认证
        /// </summary>
        UnAuthorizedRequest = 1000,

        /// <summary>
        /// 未授权
        /// </summary>
        UnPemissionedRequest = 2000
    }
}
