using System;

namespace CML.Lib.Logger.NLogger
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：NLogLogger.cs
    /// 类属性：内部类（非静态）
    /// 类功能描述：NLogLogger
    /// 创建标识：yjq 2017/7/12 17:33:47
    /// </summary>
    internal sealed class NLogLogger : ILogger
    {
        private readonly NLog.ILogger _log;

        public NLogLogger(NLog.ILogger log)
        {
            _log = log;
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _log.Debug(format, args);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(Exception exception)
        {
            _log.Error(exception, string.Empty);
        }

        public void Error(string message, Exception exception)
        {
            _log.Error(exception, message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _log.Error(format, args);
        }

        public void Fatal(string message)
        {
            _log.Fatal(message);
        }

        public void Fatal(Exception exception)
        {
            _log.Fatal(exception, string.Empty);
        }

        public void Fatal(string message, Exception exception)
        {
            _log.Fatal(exception, message);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _log.Fatal(format, args);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _log.Info(format, args);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Warn(Exception exception)
        {
            _log.Warn(exception, string.Empty);
        }

        public void Warn(string message, Exception exception)
        {
            _log.Warn(exception, message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _log.Warn(format, args);
        }
    }
}