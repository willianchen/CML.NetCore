using System;
using System.Collections.Generic;
using System.Text;

namespace CML.MQ.RabbitMQ
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RabbitMQFactory.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RabbitMQFactory
    /// 创建标识：cml 2018/3/12 16:06:49
    /// </summary>
    public class RabbitMQFactory : IMQFactory
    {
        /// <summary>
        /// 创建一个RabbitMq客户端
        /// </summary>
        /// <param name="mqConfig">mq配置信息</param>
        /// <returns>RabbitMq客户端</returns>
        public IMQClient Create(MQConfig mqConfig)
        {
            return new RabbitMQClient(mqConfig);
        }
    }
}