using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：NullPermissionCheck.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NullPermissionCheck
    /// 创建标识：cml 2018/4/8 16:41:18
    /// </summary>
    public class NullPermissionChecker : IPermissionChecker
    {
        public Task<bool> IsGrantedAsync(bool isRequireAllPermisions, string[] permissionName)
        {
            var result = false;
            foreach (var p in permissionName)
                result = p == "Test";
            return Task.FromResult(result);
        }

        public Task<bool> IsGrantedAsync(string parentPageUrl, string currentPageUrl, string[] permissionName = null, string urlParams = "")
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsGrantedAsync(string[] permissionName)
        {
            var result = false;
            //foreach (var p in permissionName)
            //    result = p == "Test";
            return Task.FromResult(result);
        }
    }
}
