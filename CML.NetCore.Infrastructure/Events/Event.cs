using CML.Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Events
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：Event.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Event
    /// 创建标识：cml 2018/3/30 16:09:47
    /// </summary>
    public class Event : IEvent
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        public Event()
        {
            Id = Guid.NewGuid().ToString();
            Time = DateTime.Now;
        }

        /// <summary>
        /// 事件标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 事件时间
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// 输出日志
        /// </summary>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"事件标识: {Id}");
            result.AppendLine($"事件时间: {Time}");
            result.Append($"事件数据：{(this).ToJson()}");
            return result.ToString();
        }
    }
}

