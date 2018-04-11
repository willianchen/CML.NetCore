using CML.AspNetCore.Extensions;
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
    /// 类名：ModelStateAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ModelStateAttribute
    /// 创建标识：cml 2018/4/11 13:57:38
    /// </summary>
    public class ModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                var error = modelState.ToMvcAjaxResponse();
                actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                actionContext.Result = new ObjectResult(error);
            }
        }
    }
}

