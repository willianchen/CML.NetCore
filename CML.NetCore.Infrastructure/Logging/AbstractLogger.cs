using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AbstractInternalLogger.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AbstractInternalLogger
    /// 创建标识：cml 2018/1/22 14:41:23
    /// </summary>
    public abstract class AbstractLogger : ILog
    {
        static readonly string EXCEPTION_MESSAGE = "Unexpected exception:";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        /// <param name="name"></param>
        protected AbstractLogger(string name)
        {
            Contract.Requires(name != null);
            this.Name = name;
        }

        public string Name { get; }

        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.TRACE:
                    return this.TraceEnabled;
                case LogLevel.DEBUG:
                    return this.DebugEnabled;
                case LogLevel.INFO:
                    return this.InfoEnabled;
                case LogLevel.WARN:
                    return this.WarnEnabled;
                case LogLevel.ERROR:
                    return this.ErrorEnabled;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public abstract bool TraceEnabled { get; }

        public abstract void Trace(string msg);

        public abstract void Trace(string msg, Exception t);

        public void Trace(Exception t) => this.Trace(EXCEPTION_MESSAGE, t);

        public abstract bool DebugEnabled { get; }

        public abstract void Debug(string msg);

        public abstract void Debug(string msg, Exception t);

        public void Debug(Exception t) => this.Debug(EXCEPTION_MESSAGE, t);

        public abstract bool InfoEnabled { get; }

        public abstract void Info(string msg);

        public abstract void Info(string msg, Exception t);

        public void Info(Exception t) => this.Info(EXCEPTION_MESSAGE, t);

        public abstract bool WarnEnabled { get; }

        public abstract void Warn(string msg);

        public abstract void Warn(string msg, Exception t);

        public void Warn(Exception t) => this.Warn(EXCEPTION_MESSAGE, t);

        public abstract bool ErrorEnabled { get; }

        public abstract void Error(string msg);

        public abstract void Error(string msg, Exception t);

        public void Error(Exception t) => this.Error(EXCEPTION_MESSAGE, t);

        public void Log(LogLevel level, string msg, Exception cause)
        {
            switch (level)
            {
                case LogLevel.TRACE:
                    this.Trace(msg, cause);
                    break;
                case LogLevel.DEBUG:
                    this.Debug(msg, cause);
                    break;
                case LogLevel.INFO:
                    this.Info(msg, cause);
                    break;
                case LogLevel.WARN:
                    this.Warn(msg, cause);
                    break;
                case LogLevel.ERROR:
                    this.Error(msg, cause);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Log(LogLevel level, Exception cause)
        {
            switch (level)
            {
                case LogLevel.TRACE:
                    this.Trace(cause);
                    break;
                case LogLevel.DEBUG:
                    this.Debug(cause);
                    break;
                case LogLevel.INFO:
                    this.Info(cause);
                    break;
                case LogLevel.WARN:
                    this.Warn(cause);
                    break;
                case LogLevel.ERROR:
                    this.Error(cause);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Log(LogLevel level, string msg)
        {
            switch (level)
            {
                case LogLevel.TRACE:
                    this.Trace(msg);
                    break;
                case LogLevel.DEBUG:
                    this.Debug(msg);
                    break;
                case LogLevel.INFO:
                    this.Info(msg);
                    break;
                case LogLevel.WARN:
                    this.Warn(msg);
                    break;
                case LogLevel.ERROR:
                    this.Error(msg);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString() => this.GetType().Name + '(' + this.Name + ')';
    }
}