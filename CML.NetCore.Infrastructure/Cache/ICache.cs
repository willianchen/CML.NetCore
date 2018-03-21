using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Cache
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ICache.cs
    /// 类属性：接口
    /// 类功能描述：缓存抽象接口
    /// 创建标识：cml 2018/3/19 17:16:03
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 唯一缓存名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 默认相对缓存失效时间
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }


        /// <summary>
        /// 获取缓存信息
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="func"></param>
        /// <returns></returns>

        object Get(string key, Func<string, object> func);


        /// <summary>
        /// 获取缓存信息（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<object> GetAsync(string key, Func<string, Task<object>> func);

        /// <summary>
        /// 获取缓存信息，未找到返回空
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object GetOrDefault(string key);

        /// <summary>
        /// 获取缓存信息，未找到返回空（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<object> GetOrDefaultAsync(string key);


        /// <summary>
        /// 设置相对缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpireTime"></param>
        void SetSlidingCache(string key, object value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// 设置相对缓存（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpireTime"></param>
        Task SetSlidingCacheAsync(string key, object value, TimeSpan? slidingExpireTime = null);


        /// <summary>
        /// 设置绝对缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpireTime"></param>
        void SetAbsoluteCache(string key, object value, DateTimeOffset? absoluteExpireTime = null);

        /// <summary>
        /// 设置绝对缓存（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpireTime"></param>
        Task SetAbsoluteCacheAsync(string key, object value, DateTimeOffset? absoluteExpireTime = null);

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">Key</param>
        void Remove(string key);

        /// <summary>
        /// 移除缓存（异步）
        /// </summary>
        /// <param name="key">Key</param>
        Task RemoveAsync(string key);

        /// <summary>
        /// 清空缓存
        /// </summary>
        void Clear();

        /// <summary>
        /// 清空缓存(异步)
        /// </summary>
        Task ClearAsync();
    }
}
