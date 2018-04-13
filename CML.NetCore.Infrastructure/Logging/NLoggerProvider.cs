using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：NLoggerProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NLoggerProvider
    /// 创建标识：cml 2018/1/23 11:48:21
    /// </summary>
    public class NLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) =>new NLoggerBuilder(categoryName);


        public void Dispose()
        {
        }


    }
}
