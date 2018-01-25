using CML.Lib.Dependency;
using CML.Lib.Extensions;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：LogUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：日志记录帮助类
    /// 创建标识：yjq 2017/7/12 17:30:11
    /// </summary>
    public static class LogUtil
    {
      //  private static ILogger logger = LogManager.GetCurrentClassLogger();
        #region ILogger

        /// <summary>
        /// 获取创建ILogger工厂
        /// </summary>
        /// <returns>ILogger工厂</returns>
        private static ILoggerFactory GetLoggerFactory()
        {
            return new LogManager.GetCurrentClassLogger("");
        }

        /// <summary>
        /// 获取ILogger
        /// </summary>
        /// <param name="loggerName">记录器名字</param>
        /// <returns>ILogger</returns>
        private static IEnumerable<ILogger> GetLogger(string loggerName = null)
        {
            if (string.IsNullOrWhiteSpace(loggerName))
            {
                loggerName = "CML.Lib.Public.*";
            }
            foreach (var item in ContainerManager.Resolve<IEnumerable<ILoggerFactory>>())
            {
                yield return item.Create(loggerName);
            }
            // return GetLoggerFactory().Create(loggerName);
        }

        #endregion ILogger

        /// <summary>
        /// 输出调试日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Debug(string msg, string loggerName = null)
        {
            foreach (var logger in GetLogger(loggerName: loggerName))
            {
                logger.Debug(msg);
            }
            //GetLogger(loggerName: loggerName).Debug(msg);
        }

        /// <summary>
        /// 输出普通日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Info(string msg, string loggerName = null)
        {
            //GetLogger(loggerName: loggerName).Info(msg);
            foreach (var logger in GetLogger(loggerName: loggerName))
            {
                logger.Info(msg);
            }
        }

        /// <summary>
        /// 输出警告日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="loggerName"></param>
        public static void Warn(string msg, string loggerName = null)
        {
            //GetLogger(loggerName: loggerName).Warn(msg);
            foreach (var logger in GetLogger(loggerName: loggerName))
            {
                logger.Warn(msg);
            }
        }

        /// <summary>
        /// 输出警告日志信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="memberName"></param>
        /// <param name="loggerName"></param>
        public static void Warn(Exception ex, string memberName = null, string loggerName = null)
        {
            //GetLogger(loggerName: loggerName).Warn(ex.ToErrMsg(memberName: memberName));
            foreach (var logger in GetLogger(loggerName: loggerName))
            {
                logger.Warn(ex.ToErrMsg(memberName: memberName));
            }
        }

        /// <summary>
        /// 输出错误日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Error(string msg, string loggerName = null)
        {
            //GetLogger(loggerName: loggerName).Error(msg);
            foreach (var logger in GetLogger(loggerName: loggerName))
            {
                logger.Error(msg);
            }
        }

        /// <summary>
        /// 输出错误日志信息
        /// </summary>
        /// <param name="ex">异常信息</param>
        public static void Error(Exception ex, string memberName = null, string loggerName = null)
        {
            // GetLogger(loggerName: loggerName).Error(ex.ToErrMsg(memberName: memberName));
            foreach (var logger in GetLogger(loggerName: loggerName))
            {
                logger.Error(ex.ToErrMsg(memberName: memberName));
            }
        }

        /// <summary>
        /// 输出严重错误日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Fatal(string msg, string loggerName = null)
        {
            //GetLogger(loggerName: loggerName).Fatal(msg);
            foreach (var logger in GetLogger(loggerName: loggerName))
            {
                logger.Fatal(msg);
            }
        }

        /// <summary>
        /// 输出严重错误日志信息
        /// </summary>
        /// <param name="ex">异常信息</param>
        public static void Fatal(Exception ex, string memberName = null, string loggerName = null)
        {
            //GetLogger(loggerName: loggerName).Fatal(ex.ToErrMsg(memberName: memberName));
            foreach (var logger in GetLogger(loggerName: loggerName))
            {
                logger.Fatal(ex.ToErrMsg(memberName: memberName));
            }
        }
    }
}