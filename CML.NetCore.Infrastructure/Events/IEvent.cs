using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Events
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IEvent.cs
    /// 类属性：接口
    /// 类功能描述：事件
    /// 创建标识：cml 2018/3/30 16:08:21
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// 事件标识
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// 事件时间
        /// </summary>
        DateTime Time { get; }
    }
}
