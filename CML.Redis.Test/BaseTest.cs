using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Redis.Test
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：BaseTest.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BaseTest
    /// 创建标识：cml 2018/3/21 14:52:25
    /// </summary>
    public class BaseTest
    {
        public  static RedisConfig redisConfig
        {
            get
            {
                return new RedisConfig
                {
                    ConnectionString = "localhost:6379,allowAdmin=true",
                    DatabaseId = 1,
                    Prefix = "Test"
                };
            }
        }
    }
}
