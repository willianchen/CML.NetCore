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
    sealed class GenericLogger : AbstractInternalLogger
    {
        static readonly Func<string, Exception, string> MessageFormatterFunc = (s, e) => s;
        readonly ILogger logger;

        public GenericLogger(string name, ILogger logger)
            : base(name)
        {
            this.logger = logger;
        }

        public override bool TraceEnabled => this.logger.IsEnabled(LogLevel.Trace);

        public override void Trace(string msg) => this.logger.Log(LogLevel.Trace, 0, msg, null, MessageFormatterFunc);

        public override void Trace(string format, object arg)
        {
            if (this.TraceEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                this.logger.Log(LogLevel.Trace, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Trace(string format, object argA, object argB)
        {
            if (this.TraceEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                this.logger.Log(LogLevel.Trace, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Trace(string format, params object[] arguments)
        {
            if (this.TraceEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                this.logger.Log(LogLevel.Trace, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Trace(string msg, Exception t) => this.logger.Log(LogLevel.Trace, 0, msg, t, MessageFormatterFunc);

        public override bool DebugEnabled => this.logger.IsEnabled(LogLevel.Debug);

        public override void Debug(string msg) => this.logger.Log(LogLevel.Debug, 0, msg, null, MessageFormatterFunc);

        public override void Debug(string format, object arg)
        {
            if (this.DebugEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                this.logger.Log(LogLevel.Debug, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Debug(string format, object argA, object argB)
        {
            if (this.DebugEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                this.logger.Log(LogLevel.Debug, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Debug(string format, params object[] arguments)
        {
            if (this.DebugEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                this.logger.Log(LogLevel.Debug, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Debug(string msg, Exception t) => this.logger.Log(LogLevel.Debug, 0, msg, t, MessageFormatterFunc);

        public override bool InfoEnabled => this.logger.IsEnabled(LogLevel.Information);

        public override void Info(string msg) => this.logger.Log(LogLevel.Information, 0, msg, null, MessageFormatterFunc);

        public override void Info(string format, object arg)
        {
            if (this.InfoEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                this.logger.Log(LogLevel.Information, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Info(string format, object argA, object argB)
        {
            if (this.InfoEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                this.logger.Log(LogLevel.Information, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Info(string format, params object[] arguments)
        {
            if (this.InfoEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                this.logger.Log(LogLevel.Information, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Info(string msg, Exception t) => this.logger.Log(LogLevel.Information, 0, msg, t, MessageFormatterFunc);

        public override bool WarnEnabled => this.logger.IsEnabled(LogLevel.Warning);

        public override void Warn(string msg) => this.logger.Log(LogLevel.Warning, 0, msg, null, MessageFormatterFunc);

        public override void Warn(string format, object arg)
        {
            if (this.WarnEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                this.logger.Log(LogLevel.Warning, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Warn(string format, object argA, object argB)
        {
            if (this.WarnEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                this.logger.Log(LogLevel.Warning, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Warn(string format, params object[] arguments)
        {
            if (this.WarnEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                this.logger.Log(LogLevel.Warning, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Warn(string msg, Exception t) => this.logger.Log(LogLevel.Warning, 0, msg, t, MessageFormatterFunc);

        public override bool ErrorEnabled => this.logger.IsEnabled(LogLevel.Error);

        public override void Error(string msg) => this.logger.Log(LogLevel.Error, 0, msg, null, MessageFormatterFunc);

        public override void Error(string format, object arg)
        {
            if (this.ErrorEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, arg);
                this.logger.Log(LogLevel.Error, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Error(string format, object argA, object argB)
        {
            if (this.ErrorEnabled)
            {
                FormattingTuple ft = MessageFormatter.Format(format, argA, argB);
                this.logger.Log(LogLevel.Error, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Error(string format, params object[] arguments)
        {
            if (this.ErrorEnabled)
            {
                FormattingTuple ft = MessageFormatter.ArrayFormat(format, arguments);
                this.logger.Log(LogLevel.Error, 0, ft.Message, ft.Exception, MessageFormatterFunc);
            }
        }

        public override void Error(string msg, Exception t) => this.logger.Log(LogLevel.Error, 0, msg, t, MessageFormatterFunc);
    }
}