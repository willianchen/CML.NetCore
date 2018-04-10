using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Events.Handlers
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IEventHandler.cs
    /// 类属性：接口
    /// 类功能描述：事件处理器
    /// 创建标识：cml 2018/3/30 16:11:33
    /// </summary>
    public interface IEventHandler
    {
    }

    /// <summary>
    /// 事件处理器
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
    {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        void Handle(TEvent @event);
    }
}
