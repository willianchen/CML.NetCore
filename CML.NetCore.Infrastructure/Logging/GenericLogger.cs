using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：GenericLogger.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：GenericLogger
    /// 创建标识：cml 2018/1/23 11:20:21
    /// </summary>
    sealed class GenericLogger : AbstractLogger
    {
        static readonly Func<string, Exception, string> MessageFormatterFunc = (s, e) => s;
        readonly ILogger logger;

        public GenericLogger(string name, ILogger logger)
            : base(name)
        {
            this.logger = logger;
        }

        public override bool TraceEnabled => this.logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace);

        public override void Trace(string msg) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Trace, 0, msg, null, MessageFormatterFunc);

        public override void Trace(string msg, Exception t) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Trace, 0, msg, t, MessageFormatterFunc);

        public override bool DebugEnabled => this.logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Debug);

        public override void Debug(string msg) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Debug, 0, msg, null, MessageFormatterFunc);

        public override void Debug(string msg, Exception t) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Debug, 0, msg, t, MessageFormatterFunc);

        public override bool InfoEnabled => this.logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Information);

        public override void Info(string msg) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Information, 0, msg, null, MessageFormatterFunc);

        public override void Info(string msg, Exception t) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Information, 0, msg, t, MessageFormatterFunc);

        public override bool WarnEnabled => this.logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Warning);

        public override void Warn(string msg) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Warning, 0, msg, null, MessageFormatterFunc);

        public override void Warn(string msg, Exception t) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Warning, 0, msg, t, MessageFormatterFunc);

        public override bool ErrorEnabled => this.logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Error);

        public override void Error(string msg) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Error, 0, msg, null, MessageFormatterFunc);


        public override void Error(string msg, Exception t) => this.logger.Log(Microsoft.Extensions.Logging.LogLevel.Error, 0, msg, t, MessageFormatterFunc);
    }
}