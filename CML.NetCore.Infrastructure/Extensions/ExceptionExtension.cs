using CML.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ExceptionExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ExceptionExtension
    /// 创建标识：cml 2018/3/12 15:40:51
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// 获取错误异常信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="memberName">出现异常的方法名字</param>
        /// <returns>错误异常信息</returns>
        public static string ToErrMsg(this Exception ex, string memberName = null)
        {
            Utils.String errorBuilder = new Utils.String();
            if (!string.IsNullOrWhiteSpace(memberName))
            {
                errorBuilder.Append("CallerMemberName：{0}", memberName).AppendLine();
            }
            errorBuilder.Append("Message：{0}", ex.Message).AppendLine();
            if (ex.InnerException != null)
            {
                if (!string.Equals(ex.Message, ex.InnerException.Message, StringComparison.OrdinalIgnoreCase))
                {
                    errorBuilder.Append("InnerException：{0}", ex.InnerException.Message).AppendLine();
                }
            }
            errorBuilder.Append("Source：{0}", ex.Source).AppendLine();
            errorBuilder.Append("StackTrace：{0}", ex.StackTrace).AppendLine();
            if (WebUtil.HttpContext.IsNotNull())
            {
                errorBuilder.Append("RealIP：{0}", WebUtil.Ip).AppendLine();
                errorBuilder.Append("HttpRequestUrl：{0}", WebUtil.Url).AppendLine();
                errorBuilder.Append("Browser：{0}", WebUtil.Browser).AppendLine();
            }
            return errorBuilder.ToString();
        }
    }
}
