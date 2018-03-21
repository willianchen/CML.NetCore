using CML.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Redis
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RedisBaseRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Redis缓存访问基础类
    /// 创建标识：cml 2018/3/20 11:13:04
    /// </summary>
    public class RedisBaseRepository
    {
        private readonly IRedisProvider _redisProvider;
        private readonly RedisConfig _redisConfig;
        private IRedisClient _clien;

        public RedisBaseRepository(IRedisProvider redisProvider, RedisConfig redisConfig)
        {
            EnsureUtil.NotNull(redisProvider, "IRedisProvider");
            EnsureUtil.NotNull(redisConfig, "RedisConfig");
            _redisProvider = redisProvider;
            _redisConfig = redisConfig;
        }

        /// <summary>
        /// 配置信息
        /// </summary>
        protected RedisConfig Config
        {
            get
            {
                return _redisConfig;
            }
        }

        /// <summary>
        /// Redis实例
        /// </summary>
        public IRedisClient RedisClient
        {
            get
            {
                return _clien ?? (_clien = _redisProvider.CreateClient(_redisConfig));
            }
        }
    }
}
