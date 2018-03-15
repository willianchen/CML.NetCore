using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Redis
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IRedisConfigProvider.cs
    /// 类属性：接口
    /// 类功能描述：IRedisConfigProvider
    /// 创建标识：cml 2018/3/13 16:30:47
    /// </summary>
    interface IRedisConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        RedisConfig GetRedisConfig();
    }
}
