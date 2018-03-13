using RabbitMQ.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace CML.MQ.RabbitMQ
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RabbitMQConnectionFactory.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RabbitMQConnectionFactory
    /// 创建标识：cml 2018/3/12 11:33:41
    /// </summary>
    internal sealed class RabbitMQConnectionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static ConcurrentDictionary<string, IConnection> _connCache = new ConcurrentDictionary<string, IConnection>();

        private RabbitMQConnectionFactory()
        {
        }

        /// <summary>
        /// 获取mq连接信息
        /// </summary>
        /// <param name="mqConfig">配置信息</param>
        /// <returns></returns>
        public static IConnection CreateConnection(MQConfig mqConfig)
        {
            if (!IsExistConnection(mqConfig))
            {
                lock (_connCache)
                {
                    if (!IsExistConnection(mqConfig))
                    {
                        _connCache[mqConfig.ToString()] = new ConnectionFactory
                        {
                            HostName = mqConfig.HostName,
                            Password = mqConfig.Password,
                            NetworkRecoveryInterval = mqConfig.NetworkRecoveryInterval,
                            RequestedHeartbeat = mqConfig.RequestedHeartbeat,
                            UserName = mqConfig.UserName,
                            VirtualHost = mqConfig.VirtualHost
                        }.CreateConnection();
                    }
                }
            }
            return _connCache[mqConfig.ToString()];
        }

        private static bool IsExistConnection(MQConfig config)
        {
            return _connCache.ContainsKey(config.ToString());
        }

        /// <summary>
        /// 释放连接
        /// </summary>
        public static void DisposeConnection()
        {
            lock (_connCache)
            {
                foreach (var item in _connCache)
                {
                    item.Value?.Close();
                    item.Value?.Dispose();
                }
                _connCache.Clear();
            }
        }
    }
}
