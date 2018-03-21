using CML.Redis.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Redis
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IRedisProvider.cs
    /// 类属性：接口
    /// 类功能描述：IRedisProvider
    /// 创建标识：cml 2018/3/19 15:59:19
    /// </summary>
    public interface IRedisProvider
    {
        /// <summary>
        /// 创建redis客户端
        /// </summary>
        /// <param name="redisConfig">redis配置信息</param>
        /// <returns></returns>
        IRedisClient CreateClient(RedisConfig redisConfig);

        /// <summary>
        /// 创建redis客户端
        /// </summary>
        /// <param name="redisConfig">redis配置信息</param>
        /// <param name="serializer">序列化类</param>
        /// <returns></returns>
        IRedisClient CreateClient(RedisConfig redisConfig, IRedisBinarySerializer serializer);
    }
}
