using CML.Lib.Web;
using System;
using System.Text;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ExceptionExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：ExceptionExtension
    /// 创建标识：yjq 2017/6/11 21:54:33
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
            StringBuilder errorBuilder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(memberName))
            {
                errorBuilder.AppendFormat("CallerMemberName：{0}", memberName).AppendLine();
            }
            errorBuilder.AppendFormat("Message：{0}", ex.Message).AppendLine();
            if (ex.InnerException != null)
            {
                if (!string.Equals(ex.Message, ex.InnerException.Message, StringComparison.OrdinalIgnoreCase))
                {
                    errorBuilder.AppendFormat("InnerException：{0}", ex.InnerException.Message).AppendLine();
                }
            }
            errorBuilder.AppendFormat("Source：{0}", ex.Source).AppendLine();
            errorBuilder.AppendFormat("StackTrace：{0}", ex.StackTrace).AppendLine();
            if (WebUtil.IsHaveHttpContext())
            {
                errorBuilder.AppendFormat("RealIP：{0}", WebUtil.GetRealIP()).AppendLine();
                errorBuilder.AppendFormat("HttpRequestUrl：{0}", WebUtil.GetHttpRequestUrl()).AppendLine();
                errorBuilder.AppendFormat("UserAgent：{0}", WebUtil.GetUserAgent()).AppendLine();
            }
            return errorBuilder.ToString();
        }
    }
}