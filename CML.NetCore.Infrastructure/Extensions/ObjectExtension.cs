using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ObjectExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ObjectExtension
    /// 创建标识：cml 2018/1/25 15:55:22
    /// </summary>
    public static  class ObjectExtension
    {
        /// <summary>
        /// object ToString转化
        /// </summary>
        /// <param name="dataColumn">object</param>
        /// <returns></returns>
        public static string ToSafeString(this object obj)
        {
            if (obj == null) return string.Empty;
            return obj.ToString().Trim();
        }
    }
}
