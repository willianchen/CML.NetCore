using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Web.Models
{
	/// <summary>
	/// Copyright (C) 2017 cml 版权所有。
	/// 类名：ValidationErrorInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：ValidationErrorInfo
	/// 创建标识：cml 2018/4/9 14:54:59
	/// </summary>
     [Serializable]
    public class ValidationErrorInfo
    {
        /// <summary>
        /// 错误验证信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 方法/属性名称
        /// </summary>
        public string[] Members { get; set; }

        public ValidationErrorInfo()
        {

        }

        public ValidationErrorInfo(string message)
        {
            Message = message;
        }
        
        public ValidationErrorInfo(string message, string[] members)
            : this(message)
        {
            Members = members;
        }

        public ValidationErrorInfo(string message, string member)
            : this(message, new[] { member })
        {

        }
    }
}