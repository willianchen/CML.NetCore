using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Events.Messages
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IMessageEvent.cs
    /// 类属性：接口
    /// 类功能描述：消息事件
    /// 创建标识：cml 2018/3/30 16:13:59
    /// </summary>
    public interface IMessageEvent : IEvent
    {
        /// <summary>
        /// 事件数据
        /// </summary>
        object Data { get; set; }

        /// <summary>
        /// 发送目标
        /// </summary>
        string Target { get; set; }

        /// <summary>
        /// 回调
        /// </summary>
        string Callback { get; set; }
    }
}
