using System;
using System.Web;

namespace CML.Lib.Web
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：CookieUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：Cookie工具类
    /// 创建标识：yjq 2017/7/17 9:48:51
    /// </summary>
    public static class CookieUtil
    {
        /// <summary>
        /// 清除指定Cookie
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        public static void ClearCookie(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 获取指定Cookie值
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        /// <returns></returns>
        public static string GetCookieValue(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            string str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }

        /// <summary>
        /// 添加一个Cookie（24小时过期）
        /// </summary>
        /// <param name="cookiename"></param>
        /// <param name="cookievalue"></param>
        public static void SetCookie(string cookiename, string cookievalue)
        {
            SetCookie(cookiename, cookievalue, expires: null);
        }      

        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        /// <param name="cookiename">cookie名</param>
        /// <param name="cookievalue">cookie值</param>
        /// <param name="expires">过期时间 DateTime</param>
        public static void SetCookie(string cookiename, string cookievalue, DateTime? expires)
        {
            HttpCookie cookie = new HttpCookie(cookiename)
            {
                Value = cookievalue
            };
            if (expires != null)
            {
                cookie.Expires = expires.Value;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        /// <param name="cookiename">cookie名</param>
        /// <param name="cookievalue">cookie值</param>
        /// <param name="domain">关联域</param>
        public static void SetCookie(string cookiename, string cookievalue, string domain)
        {
            SetCookie(cookiename, cookievalue, null, domain);
        }

        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        /// <param name="cookiename">cookie名</param>
        /// <param name="cookievalue">cookie值</param>
        /// <param name="expires">过期时间 DateTime</param>
        /// <param name="domain">关联域</param>
        public static void SetCookie(string cookiename, string cookievalue, DateTime? expires, string domain)
        {
            HttpCookie cookie = new HttpCookie(cookiename)
            {
                Value = cookievalue,
                Domain = domain
            };
            if (expires != null)
            {
                cookie.Expires = expires.Value;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}