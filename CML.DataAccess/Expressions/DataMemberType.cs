using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Expressions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DataMemberType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DataMemberType
    /// 创建标识：cml 2018/2/28 10:59:48
    /// </summary>
    public enum DataMemberType
    {
        /// <summary>
        /// 默认（完成组合的）
        /// </summary>
        None = 0,

        /// <summary>
        /// 字段
        /// </summary>
        Key = 1,

        /// <summary>
        /// 值
        /// </summary>
        Value = 2
    }
}