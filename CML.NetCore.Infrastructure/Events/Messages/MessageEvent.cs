using CML.Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Events.Messages
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：MessageEvent.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：消息事件
    /// 创建标识：cml 2018/3/30 16:15:43
    /// </summary>
    public class MessageEvent : Event, IMessageEvent
    {
        /// <summary>
        /// 事件数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 发送目标
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 回调
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// 输出日志
        /// </summary>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"事件标识: {Id}");
            result.AppendLine($"事件时间:{Time}");
            if (string.IsNullOrWhiteSpace(Target) == false)
                result.AppendLine($"发送目标:{Target}");
            if (string.IsNullOrWhiteSpace(Callback) == false)
                result.AppendLine($"回调:{Callback}");
            result.Append($"事件数据：{(Data).ToJson()}");
            return result.ToString();
        }
    }
}
