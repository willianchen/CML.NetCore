using System;

namespace CML.Lib.Logger.NLogger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：NLoggerFactory.cs
    /// 类属性：内部类（非静态）
    /// 类功能描述：NLoggerFactory
    /// 创建标识：yjq 2017/7/12 17:35:15
    /// </summary>
    internal sealed class NLoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// 根据loggerName创建NLogLogger
        /// </summary>
        /// <param name="loggerName">logger名字</param>
        /// <returns>NLogLogger</returns>
        public ILogger Create(string loggerName)
        {
            return new NLogLogger(NLog.LogManager.GetLogger(loggerName));
        }

        /// <summary>
        /// 根据类型创建NLogLogger
        /// </summary>
        /// <param name="loggerType">logger类型</param>
        /// <returns>NLogLogger</returns>
        public ILogger Create(Type loggerType)
        {
            return new NLogLogger(NLog.LogManager.GetLogger(loggerType.Name, loggerType));
        }
    }
}