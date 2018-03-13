using System;

namespace CML.MQ
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：MQConfig.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MQConfig
    /// 创建标识：cml 2018/3/9 15:06:30
    /// </summary>
    public class MQConfig
    {
        public MQConfig(string hostName, string userName, string password)
        {
            HostName = hostName;
            Password = password;
            UserName = userName;
        }

        /// <summary>
        /// borker地址
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 虚拟地址
        /// </summary>
        public string VirtualHost { get; set; }

        /// <summary>
        /// 心跳时间
        /// </summary>
        public ushort RequestedHeartbeat { get; set; } = 60;

        /// <summary>
        /// 连接异常中断后，重连间隔时间
        /// </summary>
        public TimeSpan NetworkRecoveryInterval { get; set; } = TimeSpan.FromMinutes(1);

        public override string ToString()
        {
            return $"{HostName}_{VirtualHost}_{UserName}";
        }
    }
}