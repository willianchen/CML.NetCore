using CML.Lib.Result;
using CML.Lib.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CML.AspNetCore.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ModelStateExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ModelStateExtension
    /// 创建标识：cml 2018/4/11 13:53:32
    /// </summary>
    public static class ModelStateExtension
    {
        /// <summary>
        /// 验证参数并返回错误信息
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static AjaxResponse ToMvcAjaxResponse(this ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                return new AjaxResponse();
            }

            var validationErrors = new List<ValidationErrorInfo>();

            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    validationErrors.Add(new ValidationErrorInfo(error.ErrorMessage, state.Key));
                }
            }

            var errorInfo = new ErrorInfo("ValidationError")
            {
                ValidationErrors = validationErrors.ToArray()
            };

            return new AjaxResponse(errorInfo);
        }

        /// <summary>
        /// 获取首个错误信息
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string GetFirstErrorMsg(this ModelStateDictionary modelState)
        {
            if (modelState == null) return string.Empty;
            if (!modelState.IsValid)
            {
                string error = string.Empty;
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors.Any())
                    {
                        error = state.Errors.First().ErrorMessage;
                        break;
                    }
                }
                return error;
            }
            return string.Empty;
        }
    }
}
