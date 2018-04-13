using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Logging.Aspect
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DebugLogAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Debug日志
    /// 创建标识：cml 2018/4/13 16:52:22
    /// </summary>
    public class DebugLogAttribute : LogAttributeBase
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        protected override bool Enabled(ILog log)
        {
            return log.DebugEnabled;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected override void WriteLog(ILog log, string content)
        {
            log.Debug(content); 
        }
    }
}
