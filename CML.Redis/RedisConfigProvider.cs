using CML.Lib.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Redis
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RedisConfigProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RedisConfigProvider
    /// 创建标识：cml 2018/3/13 16:32:27
    /// </summary>
    public class RedisConfigProvider : IRedisConfigProvider
    {
        /// <summary>
        /// 配置文件名称
        /// </summary>
        private const string _configKey = "Options.Config.Redis";

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
