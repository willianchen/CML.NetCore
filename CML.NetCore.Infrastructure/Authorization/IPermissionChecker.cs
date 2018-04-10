using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IPermissionChecker.cs
    /// 类属性：接口
    /// 类功能描述：权限认证接口
    /// 创建标识：cml 2018/4/2 16:52:49
    /// </summary>
    public interface IPermissionChecker
    {
        /// <summary>
        /// 验证是否权限通过
        /// </summary>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        Task<bool> IsGrantedAsync(bool isRequireAllPermisions, string[] permissionName);

        /// <summary>
        /// 验证是否权限通过
        /// </summary>
        /// <param name="parentPageUrl">父页面Url</param>
        /// <param name="currentPageUrl">当前页面Url</param>
        /// <param name="permissionName">模块名称</param>
        /// <param name="urlParams">验证参数</param>
        /// <returns></returns>
        Task<bool> IsGrantedAsync(string parentPageUrl, string currentPageUrl, string[] permissionName = null, string urlParams = "");

        /// <summary>
        /// 验证是否权限通过
        /// </summary>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        Task<bool> IsGrantedAsync(string[] permissionName);


    }
}
