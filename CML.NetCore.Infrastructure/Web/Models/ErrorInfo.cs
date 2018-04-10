using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Web.Models
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ErrorInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：错误信息
    /// 创建标识：cml 2018/4/9 14:57:00
    /// </summary>
    [Serializable]
    public class ErrorInfo
    {
        /// <summary>
        ///  code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 错误详细
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// 错误验证信息
        /// </summary>
        public ValidationErrorInfo[] ValidationErrors { get; set; }

   
        public ErrorInfo()
        {

        }

        public ErrorInfo(string message)
        {
            Message = message;
        }

        public ErrorInfo(int code)
        {
            Code = code;
        }

        public ErrorInfo(int code, string message)
            : this(message)
        {
            Code = code;
        }

        public ErrorInfo(string message, string details)
            : this(message)
        {
            Details = details;
        }

        public ErrorInfo(int code, string message, string details)
            : this(message, details)
        {
            Code = code;
        }
    }
}