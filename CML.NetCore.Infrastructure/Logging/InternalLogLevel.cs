using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：InternalLogLevel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：日志等级
    /// 创建标识：cml 2018/1/22 14:35:04
    /// </summary>
    public enum InternalLogLevel
    {
        /// <summary>
        ///     'TRACE' log level.
        /// </summary>
        TRACE,

        /// <summary>
        ///     'DEBUG' log level.
        /// </summary>
        DEBUG,

        /// <summary>
        ///     'INFO' log level.
        /// </summary>
        INFO,

        /// <summary>
        ///     'WARN' log level.
        /// </summary>
        WARN,

        /// <summary>
        ///     'ERROR' log level.
        /// </summary>
        ERROR
    }
}
