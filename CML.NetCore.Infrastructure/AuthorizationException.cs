using CML.Lib.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CML.Lib
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AuthorizationException.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AuthorizationException
    /// 创建标识：cml 2018/4/8 14:41:16
    /// </summary>
    [Serializable]
    public class AuthorizationException : BizException
    {
        /// <summary>
        /// LogLever of the exception.
        /// Default: Warn.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Creates a new <see cref="AuthorizationException"/> object.
        /// </summary>
        public AuthorizationException()
        {
            LogLevel = LogLevel.WARN ;
        }

        /// <summary>
        /// Creates a new <see cref="AuthorizationException"/> object.
        /// </summary>
        public AuthorizationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AuthorizationException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AuthorizationException(string message)
            : base(message)
        {
            LogLevel = LogLevel.WARN;
        }

        /// <summary>
        /// Creates a new <see cref="AuthorizationException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        {
            LogLevel = LogLevel.WARN;
        }
    }
}