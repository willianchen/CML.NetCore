using CML.Redis.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Redis.StackExchangeRedis
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：StackExchangeRedisProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：StackExchangeRedisProvider
    /// 创建标识：cml 2018/3/21 11:33:26
    /// </summary>
    public sealed class StackExchangeRedisProvider : IRedisProvider
    {
        public StackExchangeRedisProvider()
        {
        }

        /// <summary>
        /// 创建redis客户端
        /// </summary>
        /// <param name="redisConfig">redis配置信息</param>
        /// <returns></returns>
        public IRedisClient CreateClient(RedisConfig redisConfig)
        {
            return new StackExchangeRedisClient(redisConfig, new RedisJsonBinarySerializer());
        }

        /// <summary>
        /// 创建redis客户端
        /// </summary>
        /// <param name="redisConfig">redis配置信息</param>
        /// <param name="serializer">序列化类</param>
        /// <returns></returns>
        public IRedisClient CreateClient(RedisConfig redisConfig, IRedisBinarySerializer serializer)
        {
            return new StackExchangeRedisClient(redisConfig, serializer);
        }
    }
}
