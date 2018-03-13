using CML.Lib.Dependency;
using CML.MQ.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.MQ.RegisterExtension
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：MQRegisterExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MQRegisterExtension
    /// 创建标识：cml 2018/3/12 16:07:40
    /// </summary>
    public static class MQRegisterExtension
    {
        /// <summary>
        /// 使用rabbitMQ
        /// </summary>
        /// <param name="containerManager"></param>
        /// <returns></returns>
        public static ContainerManager UseRabbitMQ(this ContainerManager containerManager)
        {
            containerManager.RegisterType<IMQFactory, RabbitMQFactory>(lifeStyle: LifeStyle.PerLifetimeScope);
            // Configuration.Instant.AddUnInStallAction(() => RabbitMQConnectionFactory.DisposeConn());
            return containerManager;
        }
    }
}