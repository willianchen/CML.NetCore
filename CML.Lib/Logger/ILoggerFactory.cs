using System;

namespace CML.Lib.Logger
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ILoggerFactory.cs
    /// 类属性：内部接口
    /// 类功能描述：ILoggerFactory接口
    /// 创建标识：yjq 2017/7/12 17:33:00
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// 根据loggerName创建ILogger
        /// </summary>
        /// <param name="loggerName">logger名字</param>
        /// <returns>ILogger</returns>
        ILogger Create(string loggerName);

        /// <summary>
        /// 根据类型创建ILogger
        /// </summary>
        /// <param name="loggerType">logger类型</param>
        /// <returns>ILogger</returns>
        ILogger Create(Type loggerType);
    }
}