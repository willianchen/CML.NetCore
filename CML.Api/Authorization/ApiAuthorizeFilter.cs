using CML.AspNetCore.Extensions;
using CML.AspNetCore.Result;
using CML.Lib;
using CML.Lib.Authorization;
using CML.Lib.Dependency;
using CML.Lib.Exceptions;
using CML.Lib.Result;
using CML.Lib.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CML.AspNetCore.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ApiAuthorizeFilter.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ApiAuthorizeFilter
    /// 创建标识：cml 2018/4/3 14:14:31
    /// </summary>
    public class ApiAuthorizeFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationHelper _authorizationHelper;
        public ApiAuthorizeFilter(IAuthorizationHelper authorizationHelper)
        {
            _authorizationHelper = authorizationHelper;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Allow Anonymous skips all authorization
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            if (!context.ActionDescriptor.IsControllerAction())
            {
                return;
            }

            //TODO: Avoid using try/catch, use conditional checking
            try
            {
                await _authorizationHelper.AuthorizeAsync(
                    context.ActionDescriptor.GetMethodInfo(),
                    context.ActionDescriptor.GetMethodInfo().DeclaringType
                );
            }
            catch (AuthorizationException ex)
            {
                LogUtil.Warn(ex);

                if (ActionResultHelper.IsObjectResult(context.ActionDescriptor.GetMethodInfo().ReturnType))
                {
                    var isLogin = await _authorizationHelper.CheckLoginAsync();

                    var errorInfo = ExceptionConvertUtil.Convert(ex);
                        //SingletonDependency<ExceptionErrorInfoConverter>.Instance.Convert(ex);
                        // context.Result = new ObjectResult(new AjaxResponse(errorInfo));

                    context.Result = new ObjectResult(new AjaxResponse(errorInfo))
                    {
                        StatusCode = isLogin ? (int)System.Net.HttpStatusCode.Forbidden : (int)System.Net.HttpStatusCode.Unauthorized
                    };
                }
                else
                {
                    context.Result = new ChallengeResult();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
                if (ActionResultHelper.IsObjectResult(context.ActionDescriptor.GetMethodInfo().ReturnType))
                {
                    context.Result = new ObjectResult(new OperateResult(ex))
                    {
                        StatusCode = (int)System.Net.HttpStatusCode.InternalServerError
                    };
                }
                else
                {
                    context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}