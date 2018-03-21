using System;
using System.Collections.Generic;
using System.Text;
using CML.Lib.Configurations;
using CML.Redis.Serialization;

namespace CML.Redis.Cache
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DefaultCacheRedisConfigProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：默认缓存Redis配置类
    /// 创建标识：cml 2018/3/20 10:42:33
    /// </summary>
    public class DefaultCacheRedisConfigProvider : ICacheRedisConfigProvider
    {
        /// <summary>
        /// 配置文件名称
        /// </summary>
        private const string _configKey = "Options.Cache.Config.Redis";

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
