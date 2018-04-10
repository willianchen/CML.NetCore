using CML.Lib.Events.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CML.Lib.Events.Default
{
    /// <summary>
    /// 事件处理器服务
    /// </summary>
    public class EventHandlerManager : IEventHandlerManager

    {     /// <summary>
          /// 事件处理器列表
          /// </summary>
        private readonly IEventHandler[] _handlers;

        /// <summary>
        /// 初始化事件处理器服务样例
        /// </summary>
        /// <param name="handlers">事件处理器列表</param>
        public EventHandlerManager(params IEventHandler[] handlers)
        {
            _handlers = handlers;
        }

        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        public List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent
        {
            return _handlers.Select(t => t as IEventHandler<TEvent>).ToList();
        }
    }
}
