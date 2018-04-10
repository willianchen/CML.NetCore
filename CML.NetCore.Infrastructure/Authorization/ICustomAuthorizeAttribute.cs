using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ICustomAuthorizeAttribute.cs
    /// 类属性：接口
    /// 类功能描述：自定义认证过滤器
    /// 创建标识：cml 2018/4/2 16:20:19
    /// </summary>
    public interface ICustomAuthorizeAttribute
    {
        /// <summary>
        /// 权限集合
        /// </summary>
        string[] Permissions { get; }

        /// <summary>
        /// 权限是否全部验证
        /// True:验证所有权限 False:验证其中之一
        /// </summary>
        bool RequireAllPermissions { get; set; }
    }
}
