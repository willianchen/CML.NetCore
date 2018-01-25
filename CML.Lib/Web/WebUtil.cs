using CML.Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CML.Lib.Web
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：WebUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：WebUtil
    /// 创建标识：yjq 2017/6/11 21:53:47
    /// </summary>
    public static class WebUtil
    {
        #region 获取当前网络IP

        /// <summary>
        /// 获取当前网络IP
        /// </summary>
        /// <returns>当前网络IP</returns>
        public static string GetRealIP()
        {
            if (!IsHaveHttpContext()) return string.Empty;
            string result = string.Empty;
            if (System.Web.HttpContext.Current.Request.Headers != null)
            {
                var forwardedHttpHeader = "X-FORWARDED-FOR";
                string xff = System.Web.HttpContext.Current.Request.Headers.AllKeys
                    .Where(x => forwardedHttpHeader.Equals(x, StringComparison.OrdinalIgnoreCase))
                    .Select(k => System.Web.HttpContext.Current.Request.Headers[k])
                    .FirstOrDefault();
                if (!string.IsNullOrEmpty(xff))
                {
                    string lastIp = xff.Split(new char[] { ',' }).FirstOrDefault();
                    result = lastIp;
                }
            }
            if (string.IsNullOrEmpty(result) && System.Web.HttpContext.Current.Request.UserHostAddress != null)
            {
                result = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            if (result == "::1")
                result = "127.0.0.1";
            if (!string.IsNullOrEmpty(result))
            {
                int index = result.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
                if (index > 0)
                    result = result.Substring(0, index);
            }
            else result = "0.0.0.0";
            return result;
        }

        #endregion 获取当前网络IP

        #region 获取客户端浏览器的原始用户代理信息

        /// <summary>
        /// 获取客户端浏览器的原始用户代理信息
        /// </summary>
        /// <returns></returns>
        public static string GetUserAgent()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.UserAgent;
            return string.Empty;
        }

        #endregion 获取客户端浏览器的原始用户代理信息

        #region 判断是否有网络请求上下文

        /// <summary>
        /// 判断是否有网络请求上下文
        /// </summary>
        /// <returns></returns>
        public static bool IsHaveHttpContext()
        {
            if (System.Web.HttpContext.Current != null)
            {
                try
                {
                    return System.Web.HttpContext.Current.Request != null;
                }
                catch
                {
                }
            }
            return false;
        }

        #endregion 判断是否有网络请求上下文

        #region 获取请求地址

        /// <summary>
        /// 获取请求地址
        /// </summary>
        /// <returns>请求地址</returns>
        public static string GetHttpRequestUrl()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.Url.ToString();
            return string.Empty;
        }

        /// <summary>
        /// 获取绝对Uri
        /// </summary>
        /// <returns>请求的绝对Uri</returns>
        public static string GetAbsoluteUrl()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            return string.Empty;
        }

        /// <summary>
        /// 获取当前域名
        /// </summary>
        /// <returns></returns>
        public static string GetDomain()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.Url.Scheme + "://" + System.Web.HttpContext.Current.Request.Url.Host + ":" + System.Web.HttpContext.Current.Request.Url.Port;
            return string.Empty;
        }

        /// <summary>
        /// 获取请求源的URL
        /// </summary>
        /// <returns>请求的绝对Uri</returns>
        public static string GetReferrerUrl()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.UrlReferrer.AbsolutePath;
            return string.Empty;
        }

        #endregion 获取请求地址

        #region 获取请求类型

        /// <summary>
        /// 获取请求类型
        /// </summary>
        /// <returns>请求类型</returns>
        public static string GetHttpMethod()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.RequestType;
            return string.Empty;
        }

        #endregion 获取请求类型

        #region 获取请求内容

        /// <summary>
        /// 获取请求内容
        /// </summary>
        /// <returns>请求内容</returns>
        public static string GetRequestData()
        {
            if (IsHaveHttpContext() && System.Web.HttpContext.Current.Request.Form != null)
                return System.Web.HttpContext.Current.Request.Form.ToString();
            return string.Empty;
        }

        #endregion 获取请求内容

        public static string GetMachineName()
        {
            if (IsHaveHttpContext())
            {
                IPAddress ip = IPAddress.Parse(System.Web.HttpContext.Current.Request.UserHostAddress);
                IPHostEntry ihe = Dns.GetHostEntry(ip);
                return ihe.HostName;
            }
            return string.Empty;
        }

        /// <summary>
        /// HostAddress
        /// </summary>
        /// <returns></returns>
        public static string GetUserHostName()
        {
            if (IsHaveHttpContext())
            {
                return System.Web.HttpContext.Current.Request.UserHostName;
            }
            return string.Empty;
        }

        /// <summary>
        /// UserHostAddress
        /// </summary>
        /// <returns></returns>
        public static string GetUserHostAddress()
        {
            if (IsHaveHttpContext())
            {
                return System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return string.Empty;
        }

        /// <summary>
        /// 拼接返回地址
        /// </summary>
        /// <param name="backUrl">返回地址</param>
        /// <param name="defaultBackUrl">默认返回地址</param>
        /// <param name="arguments">参数信息</param>
        /// <returns>返回地址</returns>
        public static string BuilderBackUrl(string backUrl, string defaultBackUrl = null, Dictionary<string, string> arguments = null)
        {
            string baseUrl = string.Empty;
            if (backUrl.IsNullOrEmptyWhiteSpace() && defaultBackUrl.IsNullOrEmptyWhiteSpace())
            {
                return backUrl;
            }
            else if (backUrl.IsNotNullAndNotEmptyWhiteSpace())
            {
                baseUrl = backUrl;
            }
            else
            {
                baseUrl = defaultBackUrl;
            }
            if (baseUrl.StartsWith("http:") || baseUrl.StartsWith("https:"))
            {
                EnhancedUriBuilder uriBuilder = new EnhancedUriBuilder(baseUrl);
                if (arguments != null)
                {
                    foreach (KeyValuePair<string, string> item in arguments)
                    {
                        uriBuilder.QueryItems[item.Key] = item.Value;
                    }
                }
                return uriBuilder.ToString();
            }
            else
            {
                string queryItem = string.Empty;
                if (arguments != null)
                {
                    foreach (KeyValuePair<string, string> item in arguments)
                    {
                        queryItem += item.Key + "=" + item.Value.UrlEncode("UTF-8") + "&";
                    }
                    if (queryItem.Length > 0)
                    {
                        queryItem.Substring(0, queryItem.Length - 1);
                    }
                }
                if (baseUrl.IndexOf('?') > 0)
                {
                    return baseUrl + queryItem;
                }
                else
                {
                    return baseUrl + "?" + queryItem;
                }
            }
        }
    }
}