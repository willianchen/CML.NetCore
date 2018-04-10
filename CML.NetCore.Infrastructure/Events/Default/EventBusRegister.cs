using CML.Lib.Dependency;
using CML.Lib.Events.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Events.Default
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：EventBusRegister.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：EventBusRegister
    /// 创建标识：cml 2018/3/30 18:48:34
    /// </summary>
    public static class EventBusRegister
    {
        /// <summary>
        /// EventBus注册组件
        /// </summary>
        /// <param name="containerManager"></param>
        /// <returns></returns>
        public static ContainerManager UseDefaultEventBus(this ContainerManager containerManager)
        {
            containerManager.RegisterType<IEventHandlerManager, EventHandlerManager>(lifeStyle: LifeStyle.PerLifetimeScope);
            containerManager.RegisterType<IEventBus, EventBus>(lifeStyle: LifeStyle.PerLifetimeScope);
            return containerManager;
        }
    }
}
