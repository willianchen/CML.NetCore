using CML.Lib.Authorization;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using System;

namespace CML.AspNetCore.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ApiAuthorizeAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ApiAuthorizeAttribute
    /// 创建标识：cml 2018/4/3 10:55:32
    /// </summary>
    public class ApiAuthorizeAttribute : Attribute, ICustomAuthorizeAttribute
    {
        /// <inheritdoc/>
        public string[] Permissions { get; set; }

        /// <inheritdoc/>
        public bool RequireAllPermissions { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="ApiAuthorizeAttribute"/> class.
        /// </summary>
        /// <param name="permissions">A list of permissions to authorize</param>
        public ApiAuthorizeAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }

        public ApiAuthorizeAttribute(string permission) : this(new string[] { permission })
        {

        }
    }
}
