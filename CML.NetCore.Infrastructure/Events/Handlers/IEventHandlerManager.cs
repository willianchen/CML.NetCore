using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Events.Handlers
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IEventHandlerManager.cs
    /// 类属性：接口
    /// 类功能描述：事件处理器服务
    /// 创建标识：cml 2018/3/30 16:12:25
    /// </summary>
    public interface IEventHandlerManager
    {
        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent;
    }
}
