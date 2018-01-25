using System;
using System.Runtime.Remoting.Messaging;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：AsyncLocalUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/11/13 15:15:21
    /// </summary>
    public static class AsyncLocalUtil
    {
        /// <summary>
        /// 获取当前的请求随机GID，同一次请求唯一
        /// </summary>
        public static string CurrentGID
        {
            get
            {
                var currentGID = CallContext.GetData("CurrentGID") as string;
                if (currentGID == null)
                {
                    currentGID = Guid.NewGuid().ToString("N");
                    CallContext.SetData("CurrentGID", currentGID);
                }
                return currentGID;
            }
        }
    }
}