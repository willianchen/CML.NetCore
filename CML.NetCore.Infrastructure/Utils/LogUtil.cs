using CML.Lib.Extensions;
using CML.Lib.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：LogUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：LogUtil
    /// 创建标识：cml 2018/3/12 15:04:37
    /// </summary>
    public static class LogUtil
    {
        private static ILog GetLogger(string loggerName = null)
        {
            if (string.IsNullOrWhiteSpace(loggerName))
            {
                loggerName = "Public.*";
            }
            return LogFactory.GetInstance(loggerName);
        }


        /// <summary>
        /// 输出调试日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Debug(string msg, string loggerName = null)
        {
            GetLogger(loggerName).Debug(msg);
        }

        /// <summary>
        /// 输出普通日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Info(string msg, string loggerName = null)
        {
            GetLogger(loggerName).Info(msg);
        }

        public static void Debug(object p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 输出警告日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="loggerName"></param>
        public static void Warn(string msg, string loggerName = null)
        {
            GetLogger(loggerName).Warn(msg);
        }

        /// <summary>
        /// 输出警告日志信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="memberName"></param>
        /// <param name="loggerName"></param>
        public static void Warn(Exception ex, string memberName = null, string loggerName = null)
        {
            GetLogger(loggerName).Warn(ex.ToErrMsg(memberName: memberName));
        }

        /// <summary>
        /// 输出错误日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Error(string msg, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Error(msg);
        }

        /// <summary>
        /// 输出错误日志信息
        /// </summary>
        /// <param name="ex">异常信息</param>
        public static void Error(Exception ex, string memberName = null, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Error(ex.ToErrMsg(memberName: memberName));
        }
    }
}
