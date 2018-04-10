using CML.Lib.Utils;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AuthorizationHelper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AuthorizationHelper
    /// 创建标识：cml 2018/4/3 11:50:02
    /// </summary>
    public class AuthorizationHelper : IAuthorizationHelper
    {
        public IPermissionChecker _permissionChecker { get; set; }
        public ILoginChecker _loginChecker { get; set; }

        public AuthorizationHelper(IPermissionChecker permissionChecker, ILoginChecker loginChecker)
        {
            _permissionChecker = permissionChecker;
            _loginChecker = loginChecker;
        }

        public async Task AuthorizeAsync(IEnumerable<ICustomAuthorizeAttribute> authorizeAttributes)
        {
            if (!(await CheckLoginAsync()))
            {
                throw new AuthorizationException(
                    "CurrentUserDidNotLoginToTheApplication"
                    );
            }

            foreach (var authorizeAttribute in authorizeAttributes)
            {
                var isGranted = await _permissionChecker.IsGrantedAsync(authorizeAttribute.RequireAllPermissions, authorizeAttribute.Permissions);
                if (!isGranted)
                    throw new AuthorizationException("CurrentUser UnAuthorized");
            }
        }

        public async Task<bool> CheckLoginAsync()
        {
            return await _loginChecker.IsLogin();
        }

        public async Task AuthorizeAsync(MethodInfo methodInfo, Type type)
        {
            await CheckPermissions(methodInfo, type);
        }

        private async Task CheckPermissions(MethodInfo methodInfo, Type type)
        {
            if (AllowAnonymous(methodInfo, type))
            {
                return;
            }

            var authorizeAttributes =
                ReflectionHelper
                    .GetAttributesOfMemberAndType(methodInfo, type)
                    .OfType<ICustomAuthorizeAttribute>()
                    .ToArray();

            if (!authorizeAttributes.Any())
            {
                return;
            }

            await AuthorizeAsync(authorizeAttributes);
        }

        private static bool AllowAnonymous(MemberInfo memberInfo, Type type)
        {
            return ReflectionHelper
                .GetAttributesOfMemberAndType(memberInfo, type)
                .OfType<AllowAnonymousAttribute>()
                .Any();
        }


    }
}
