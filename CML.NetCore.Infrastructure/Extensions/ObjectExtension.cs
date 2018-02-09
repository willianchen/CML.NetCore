using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CML.Lib.Helplers;
using CML.Lib.Utils;
using String = System.String;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ObjectExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ObjectExtension
    /// 创建标识：cml 2018/1/25 15:55:22
    /// </summary>
    public static class ObjectExtension
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
        /// <summary>
        /// 转换为bool
        /// </summary>
        /// <param name="obj">数据</param>
        public static bool ToBool(this object obj)
        {
            return ConvertHelper.ToBool(obj);
        }

        /// <summary>
        /// 转换为可空bool
        /// </summary>
        /// <param name="obj">数据</param>
        public static bool? ToBoolOrNull(this object obj)
        {
            return ConvertHelper.ToBoolOrNull(obj);
        }

        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="obj">数据</param>
        public static int ToInt(this object obj)
        {
            return ConvertHelper.ToInt(obj);
        }

        /// <summary>
        /// 转换为可空int
        /// </summary>
        /// <param name="obj">数据</param>
        public static int? ToIntOrNull(this object obj)
        {
            return ConvertHelper.ToIntOrNull(obj);
        }

        /// <summary>
        /// 转换为long
        /// </summary>
        /// <param name="obj">数据</param>
        public static long ToLong(this object obj)
        {
            return ConvertHelper.ToLong(obj);
        }

        /// <summary>
        /// 转换为可空long
        /// </summary>
        /// <param name="obj">数据</param>
        public static long? ToLongOrNull(this object obj)
        {
            return ConvertHelper.ToLongOrNull(obj);
        }

        /// <summary>
        /// 转换为double
        /// </summary>
        /// <param name="obj">数据</param>
        public static double ToDouble(this object obj)
        {
            return ConvertHelper.ToDouble(obj);
        }

        /// <summary>
        /// 转换为可空double
        /// </summary>
        /// <param name="obj">数据</param>
        public static double? ToDoubleOrNull(this object obj)
        {
            return ConvertHelper.ToDoubleOrNull(obj);
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="obj">数据</param>
        public static decimal ToDecimal(this object obj)
        {
            return ConvertHelper.ToDecimal(obj);
        }

        /// <summary>
        /// 转换为可空decimal
        /// </summary>
        /// <param name="obj">数据</param>
        public static decimal? ToDecimalOrNull(this object obj)
        {
            return ConvertHelper.ToDecimalOrNull(obj);
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="obj">数据</param>
        public static DateTime ToDate(this object obj)
        {
            return ConvertHelper.ToDate(obj);
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="obj">数据</param>
        public static DateTime? ToDateOrNull(this object obj)
        {
            return ConvertHelper.ToDateOrNull(obj);
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="obj">数据</param>
        public static Guid ToGuid(this object obj)
        {
            return ConvertHelper.ToGuid(obj);
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        /// <param name="obj">数据</param>
        public static Guid? ToGuidOrNull(this object obj)
        {
            return ConvertHelper.ToGuidOrNull(obj);
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="obj">数据,范例: "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A"</param>
        public static List<Guid> ToGuidList(this string obj)
        {
            return ConvertHelper.ToGuidList(obj);
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        /// <param name="obj">字符串集合</param>
        public static List<Guid> ToGuidList(this IList<string> obj)
        {
            if (obj == null)
                return new List<Guid>();
            return obj.Select(t => t.ToGuid()).ToList();
        }

        /// <summary>
        /// 集合分隔符连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="separator">分隔符 默认逗号,</param>
        /// <returns></returns>
        public static string ToJoin<T>(this IEnumerable<T> obj, string separator = ",")
        {
            return StringTools.Join(obj, separator);
        }
    }
}
