using System.Web;

namespace CML.Lib.Web
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：SessionUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Session工具类
    /// 创建标识：yjq 2017/7/17 9:51:57
    /// </summary>
    public static class SessionUtil
    {
        /// <summary>
        /// 根据session名获取session对象
        /// </summary>
        /// <param name="name">sessionName</param>
        /// <returns></returns>
        public static object GetSession(string name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
                return HttpContext.Current.Session[name];
            return null;
        }

        /// <summary>
        /// 根据session名获取session对象
        /// </summary>
        /// <param name="TModel">实例类型</param>
        /// <param name="name">sessionName</param>
        /// <returns></returns>
        public static TModel GetSession<TModel>(string name)
        {
            if (HttpContext.Current != null)
                return (TModel)HttpContext.Current.Session[name];
            return default(TModel);
        }

        /// <summary>
        /// 设置session
        /// </summary>
        /// <param name="name">session 名</param>
        /// <param name="val">session 值</param>
        public static void SetSession(string name, object val)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session.Add(name, val);
            }
        }

        /// <summary>
        /// 添加Session，调动有效期为20分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValue">Session值</param>
        public static void Add(string strSessionName, string strValue)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session[strSessionName] = strValue;
                HttpContext.Current.Session.Timeout = 20;
            }
        }

        /// <summary>
        /// 添加Session，调动有效期为20分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValues">Session值数组</param>
        public static void Adds(string strSessionName, string[] strValues)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session[strSessionName] = strValues;
                HttpContext.Current.Session.Timeout = 20;
            }
        }

        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValue">Session值</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void Add(string strSessionName, string strValue, int iExpires)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session[strSessionName] = strValue;
                HttpContext.Current.Session.Timeout = iExpires;
            }
        }

        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValues">Session值数组</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void Adds(string strSessionName, string[] strValues, int iExpires)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session[strSessionName] = strValues;
                HttpContext.Current.Session.Timeout = iExpires;
            }
        }

        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static string Get(string strSessionName)
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session[strSessionName] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[strSessionName].ToString();
                }
            }
            return null;
        }

        /// <summary>
        /// 读取某个Session对象值数组
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值数组</returns>
        public static string[] Gets(string strSessionName)
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session[strSessionName] == null)
                {
                    return null;
                }
                else
                {
                    return (string[])HttpContext.Current.Session[strSessionName];
                }
            }
            return null;
        }

        /// <summary>
        /// 删除某个Session对象
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        public static void Del(string strSessionName)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session[strSessionName] = null;
            }
        }

        /// <summary>
        /// 清楚所有的Session
        /// </summary>
        public static void Clear()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session.Clear();
            }
        }
    }
}