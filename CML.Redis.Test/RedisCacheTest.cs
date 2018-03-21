using CML.Redis.Cache;
using CML.Redis.StackExchangeRedis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Redis.Test
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RedisCacheTest.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RedisCacheTest
    /// 创建标识：cml 2018/3/21 15:00:30
    /// </summary>
    [TestClass]
    public class RedisCacheTest : BaseTest
    {
        [TestMethod]
        public void TestRedisCache()
        {
            RedisCache redisCache = new RedisCache("redisCache", new StackExchangeRedisProvider(), redisConfig);
            redisCache.SetSlidingCache("test", "test");
            var retCache = redisCache.GetOrDefault("test");
            Console.WriteLine("result of cache:" + retCache);
            var retGetStr = redisCache.Get("result of Get func", (x) =>
              {
                  return "1111";
              });
            Console.WriteLine("result of Get fun:" + retGetStr);
        }

    }
}
