using System;
using System.Collections;
using System.Web;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：CacheUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/12 18:20:43
    /// </summary>
    public static class CacheUtil
    {
        /// <summary>
        /// 添加相对时间缓存
        /// </summary>
        /// <param name="key">需要添加缓存名称</param>
        /// <param name="obj">缓存值</param>
        /// <param name="isSlidCache">是否为相对时间</param>
        public static void AddSlidingCache(string key, object obj, TimeSpan timeOutSpan)
        {
            if (string.IsNullOrWhiteSpace(key)) return;
            if (System.Web.HttpRuntime.Cache[key] != null) RemoveCache(key);//如果原先存在则先移除
            System.Web.HttpRuntime.Cache.Insert(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, timeOutSpan);
        }

        /// <summary>
        /// 添加绝对时间缓存
        /// </summary>
        /// <param name="key">需要添加缓存名称</param>
        /// <param name="obj">缓存值</param>
        /// <param name="time">过期时间</param>
        public static void AddAbsoluteCache(string key, object obj, DateTime time)
        {
            if (string.IsNullOrWhiteSpace(key)) return;

            if (System.Web.HttpRuntime.Cache[key] != null) RemoveCache(key);//如果原先存在则先移除
            System.Web.HttpRuntime.Cache.Insert(key, obj, null, time, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">需要获取的缓存名称</param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            return IsExistCache(key) ? System.Web.HttpRuntime.Cache[key] : null;
        }

        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <param name="key">需要判断的缓存名称</param>
        /// <returns></returns>
        public static bool IsExistCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;
            return System.Web.HttpRuntime.Cache[key] == null ? false : true;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">需要移除的缓存名称</param>
        public static void RemoveCache(string key)
        {
            if (IsExistCache(key)) System.Web.HttpRuntime.Cache.Remove(key);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}