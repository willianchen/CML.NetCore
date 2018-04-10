using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Events
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IEventBus.cs
    /// 类属性：接口
    /// 类功能描述：事件总线
    /// 创建标识：cml 2018/3/30 16:09:11
    /// </summary>
   public interface IEventBus
    {
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}

