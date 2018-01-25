using CML.Lib.Utils;
using System;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：EnumExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：枚举扩展类
    /// 创建标识：yjq 2017/7/15 21:06:03
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns>枚举值的描述</returns>
        public static string Desc(this Enum enumValue)
        {
            if (enumValue == null) return string.Empty;
            return EnumUtil.GetDesc(enumValue);
        }

        /// <summary>
        /// 获取枚举值对应的描述
        /// </summary>
        /// <typeparam name="EnumType">枚举类型</typeparam>
        /// <param name="obj">枚举值</param>
        /// <returns>枚举值对应的描述</returns>
        public static string Desc<EnumType>(this object obj)
        {
            if (obj == null) return string.Empty;
            if (string.IsNullOrWhiteSpace(obj.ToString()))
            {
                return string.Empty;
            }
            return EnumUtil.GetDesc<EnumType>(obj.ToString());
        }
    }
}