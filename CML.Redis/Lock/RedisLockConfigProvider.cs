using CML.Lib.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Redis.Lock
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RedisLockConfigProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RedisLockConfigProvider
    /// 创建标识：cml 2018/3/21 11:18:04
    /// </summary>
    public class RedisLockConfigProvider : IRedisLockConfigProvider
    {
        /// <summary>
        /// 配置文件名称
        /// </summary>
        private const string _configKey = "Redis.Config.Lock";

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public RedisConfig GetRedisConfig()
        {
            var config = ConfigurationHelper.GetAppSettings<RedisConfig>(_configKey);
            return config;
        }
    }
}
