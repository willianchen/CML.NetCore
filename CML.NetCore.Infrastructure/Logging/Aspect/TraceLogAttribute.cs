using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Logging.Aspect
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：TraceLogAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：跟踪日志
    /// 创建标识：cml 2018/4/13 16:56:49
    /// </summary>
    public class TraceLogAttribute : LogAttributeBase
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        protected override bool Enabled(ILog log)
        {
            return log.TraceEnabled;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected override void WriteLog(ILog log, string content)
        {
            log.Trace(content);
        }
    }
}
