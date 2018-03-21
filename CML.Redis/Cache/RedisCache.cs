using CML.Lib.Cache;
using CML.Lib.Utils;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CML.Redis.Cache
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RedisCache.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RedisCache
    /// 创建标识：cml 2018/3/20 11:18:48
    /// </summary>
    public class RedisCache : RedisBaseRepository, ICache
    {
        public string Name { get; }

        public TimeSpan DefaultSlidingExpireTime { get; set; }


        protected readonly object SyncObj = new object();

        private readonly AsyncLock _asyncLock = new AsyncLock();


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="name"></param>
        public RedisCache(string name, IRedisProvider redisProvider, RedisConfig redisConfig) : base(redisProvider, redisConfig)
        {
            Name = name;
            DefaultSlidingExpireTime = TimeSpan.FromHours(1);
            redisConfig.Prefix = redisConfig.Prefix + redisConfig.NamespaceSplitSymbol + Name;
        }


        /// <summary>
        /// 清楚所有缓存
        /// </summary>
        public void Clear()
        {
            RedisClient.Clear();
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <returns></returns>
        public async Task ClearAsync()
        {
            RedisClient.Clear();
            await Task.FromResult(0);
        }

        /// <summary>
        /// 获取缓存信息，空则设置
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public object Get(string key, Func<string, object> func)
        {
            object item = null;

            try
            {
                item = GetOrDefault(key);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
            }

            if (item == null)
            {
                lock (SyncObj)
                {
                    try
                    {
                        item = GetOrDefault(key);
                    }
                    catch (Exception ex)
                    {
                        LogUtil.Error(ex);
                    }

                    if (item == null)
                    {
                        item = func(key);

                        if (item == null)
                        {
                            return null;
                        }

                        try
                        {
                            SetSlidingCache(key, item);
                        }
                        catch (Exception ex)
                        {
                            LogUtil.Error(ex);
                        }
                    }
                }
            }

            return item;
        }

        /// <summary>
        /// 获取缓存信息（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<object> GetAsync(string key, Func<string, Task<object>> func)
        {
            object item = null;

            try
            {
                item = await GetOrDefaultAsync(key);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
            }

            if (item == null)
            {
                using (await _asyncLock.LockAsync())
                {
                    try
                    {
                        item = await GetOrDefaultAsync(key);
                    }
                    catch (Exception ex)
                    {
                        LogUtil.Error(ex);
                    }

                    if (item == null)
                    {
                        item = await func(key);

                        if (item == null)
                        {
                            return null;
                        }

                        try
                        {
                            await SetSlidingCacheAsync(key, item);
                        }
                        catch (Exception ex)
                        {
                            LogUtil.Error(ex);
                        }
                    }
                }
            }

            return item;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetOrDefault(string key)
        {
            return RedisClient.StringGet<object>(key);
        }

        /// <summary>
        /// 获取缓存（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<object> GetOrDefaultAsync(string key)
        {
            return await RedisClient.StringGetAsync<object>(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            RedisClient.KeyRemove(key);
        }

        /// <summary>
        /// 移除缓存（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task RemoveAsync(string key)
        {
            await RedisClient.KeyRemoveAsync(key);
        }

        /// <summary>
        /// 设置绝对缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpireTime">绝对失效时间</param>
        public void SetAbsoluteCache(string key, object value, DateTimeOffset? absoluteExpireTime = null)
        {
            EnsureUtil.NotNull(value, "value can be not null");
            if (absoluteExpireTime == null)
                RedisClient.StringSet(key, value);
            else
                RedisClient.StringSet(key, value, absoluteExpireTime.Value);
        }

        /// <summary>
        /// 设置绝对缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpireTime"></param>
        /// <returns></returns>
        public async Task SetAbsoluteCacheAsync(string key, object value, DateTimeOffset? absoluteExpireTime = null)
        {
            EnsureUtil.NotNull(value, "value can be not null");
            if (absoluteExpireTime == null)
                await RedisClient.StringSetAsync(key, value);
            else
                await RedisClient.StringSetAsync(key, value, absoluteExpireTime.Value);
        }

        /// <summary>
        /// 设置相对缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpireTime"></param>
        public void SetSlidingCache(string key, object value, TimeSpan? slidingExpireTime = null)
        {
            EnsureUtil.NotNull(value, "value can be not null");
            RedisClient.StringSet(key, value, slidingExpireTime ?? DefaultSlidingExpireTime);
        }

        /// <summary>
        /// 设置相对缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpireTime"></param>
        /// <returns></returns>
        public async Task SetSlidingCacheAsync(string key, object value, TimeSpan? slidingExpireTime = null)
        {
            EnsureUtil.NotNull(value, "value can be not null");
            await RedisClient.StringSetAsync(key, value, slidingExpireTime ?? DefaultSlidingExpireTime);
        }
    }
}
