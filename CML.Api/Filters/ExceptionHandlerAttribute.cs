using CML.Lib;
using CML.Lib.Dependency;
using CML.Lib.Domains.Entities;
using CML.Lib.Exceptions;
using CML.Lib.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CML.AspNetCore.Filters
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ExceptionHandlerAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ExceptionHandlerAttribute
    /// 创建标识：cml 2018/4/9 13:31:46
    /// </summary>
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = GetStatusCode(context);
            var errorInfo = ExceptionConvertUtil.Convert(context.Exception);
            context.Result = new ObjectResult(new AjaxResponse(errorInfo));
        }

        private int GetStatusCode(ExceptionContext context)
        {
            if (context.Exception is AuthorizationException)
            {
                return (int)HttpStatusCode.Unauthorized;
            }

            if (context.Exception is EntityNotFoundException)
            {
                return (int)HttpStatusCode.NotFound;
            }

            return (int)HttpStatusCode.InternalServerError;
        }
    }
}
