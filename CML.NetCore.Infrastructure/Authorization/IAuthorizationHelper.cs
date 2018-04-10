using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IAuthorizationHelper.cs
    /// 类属性：接口
    /// 类功能描述：IAuthorizationHelper
    /// 创建标识：cml 2018/4/3 11:47:55
    /// </summary>
    public interface IAuthorizationHelper
    {
        Task AuthorizeAsync(IEnumerable<ICustomAuthorizeAttribute> authorizeAttributes);

        Task AuthorizeAsync(MethodInfo methodInfo, Type type);

        Task<bool> CheckLoginAsync();
    }
}
