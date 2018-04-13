using System;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IInternalLogger.cs
    /// 类属性：接口
    /// 类功能描述：日志抽象类
    /// 创建标识：cml 2018/1/22 14:34:34
    /// </summary>
    public interface ILog
    {  
      
        /// <summary>
        /// 实例名称
        /// </summary>
        string Name { get; }

        bool TraceEnabled { get; }

        void Trace(string msg);

        void Trace(string msg, Exception t);

        void Trace(Exception t);

        bool DebugEnabled { get; }

        void Debug(string msg);

        void Debug(string msg, Exception t);

        void Debug(Exception t);

        bool InfoEnabled { get; }

        void Info(string msg);

        void Info(string msg, Exception t);

        void Info(Exception t);

        bool WarnEnabled { get; }

        void Warn(string msg);

        void Warn(string msg, Exception t);

        void Warn(Exception t);

        bool ErrorEnabled { get; }

        void Error(string msg);

        void Error(string msg, Exception t);

        void Error(Exception t);

        bool IsEnabled(LogLevel level);

        void Log(LogLevel level, string msg);

        void Log(LogLevel level, string msg, Exception t);

        void Log(LogLevel level, Exception t);
    }
}
