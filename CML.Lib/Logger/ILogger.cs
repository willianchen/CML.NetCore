using System;

namespace CML.Lib.Logger
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ILogger.cs
    /// 类属性：内部接口
    /// 类功能描述：ILogger接口
    /// 创建标识：yjq 2017/7/12 17:31:48
    /// </summary>
    public interface ILogger
    {
        #region 调试日志

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="message">日志内容</param>
        void Debug(string message);

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="format">包含格式项的字符串</param>
        /// <param name="args">格式参数</param>
        void DebugFormat(string format, params object[] args);

        #endregion 调试日志

        #region 错误日志

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">日志内容</param>
        void Error(string message);

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">异常信息</param>
        void Error(Exception exception);

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="exception">异常信息</param>
        void Error(string message, Exception exception);

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="format">包含格式项的字符串</param>
        /// <param name="args">格式参数</param>
        void ErrorFormat(string format, params object[] args);

        #endregion 错误日志

        #region 严重危险日志

        /// <summary>
        /// 严重危险日志
        /// </summary>
        /// <param name="message">日志内容</param>
        void Fatal(string message);

        /// <summary>
        /// 严重危险日志
        /// </summary>
        /// <param name="message">异常信息</param>
        void Fatal(Exception exception);

        /// <summary>
        /// 严重危险日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="exception">异常信息</param>
        void Fatal(string message, Exception exception);

        /// <summary>
        /// 严重危险日志
        /// </summary>
        /// <param name="format">包含格式项的字符串</param>
        /// <param name="args">格式参数</param>
        void FatalFormat(string format, params object[] args);

        #endregion 严重危险日志

        #region 运行日志

        /// <summary>
        /// 运行日志
        /// </summary>
        /// <param name="message">日志内容</param>
        void Info(string message);

        /// <summary>
        /// 运行日志
        /// </summary>
        /// <param name="format">包含格式项的字符串</param>
        /// <param name="args">格式参数</param>
        void InfoFormat(string format, params object[] args);

        #endregion 运行日志

        #region 警告日志

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message">日志内容</param>
        void Warn(string message);

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message">异常信息</param>
        void Warn(Exception exception);

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="exception">异常信息</param>
        void Warn(string message, Exception exception);

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="format">包含格式项的字符串</param>
        /// <param name="args">格式参数</param>
        void WarnFormat(string format, params object[] args);

        #endregion 警告日志
    }
}