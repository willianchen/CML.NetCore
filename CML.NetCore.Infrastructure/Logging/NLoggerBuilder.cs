using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：NLoggeBuilder.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NLoggeBuilder
    /// 创建标识：cml 2018/1/23 13:33:00
    /// </summary>
    public class NLoggerBuilder : ILogger
    {
        /// <summary>
        /// NLog日志操作
        /// </summary>
        private readonly NLog.ILogger _logger;

        readonly string _name;

        public NLoggerBuilder(string name)
        {
            this._name = name;
            _logger = GetLogger(_name);
        }

        /// <summary>
        /// 获取NLog日志操作
        /// </summary>
        /// <param name="logName">日志名称</param>
        public static NLog.ILogger GetLogger(string logName)
        {
            return NLog.LogManager.GetLogger(logName);
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            switch (logLevel)
            {
                case Microsoft.Extensions.Logging.LogLevel.Trace:
                    _logger.Trace(formatter(state, exception), exception);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Debug:
                    _logger.Debug(exception, formatter(state, exception));
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Information:
                    _logger.Info(exception, formatter(state, exception));
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Warning:
                    _logger.Warn(exception, formatter(state, exception));
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Error:
                    _logger.Error(exception, formatter(state, exception));
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Critical:
                    _logger.Error(exception, formatter(state, exception));
                    break;
                case Microsoft.Extensions.Logging.LogLevel.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case Microsoft.Extensions.Logging.LogLevel.Trace:
                    return _logger.IsTraceEnabled;
                case Microsoft.Extensions.Logging.LogLevel.Debug:
                    return _logger.IsDebugEnabled;
                case Microsoft.Extensions.Logging.LogLevel.Information:
                    return _logger.IsInfoEnabled;
                case Microsoft.Extensions.Logging.LogLevel.Warning:
                    return _logger.IsWarnEnabled;
                case Microsoft.Extensions.Logging.LogLevel.Error:
                    return _logger.IsErrorEnabled;
                case Microsoft.Extensions.Logging.LogLevel.Critical:
                    return _logger.IsErrorEnabled;
                case Microsoft.Extensions.Logging.LogLevel.None:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        public IDisposable BeginScope<TState>(TState state) => NoOpDisposable.Instance;

        sealed class NoOpDisposable : IDisposable
        {
            public static readonly NoOpDisposable Instance = new NoOpDisposable();

            NoOpDisposable()
            {
            }

            public void Dispose()
            {
            }
        }
    }
}