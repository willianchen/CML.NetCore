using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DataTableExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DataTable扩展类
    /// 创建标识：cq 2017/8/29 21:07:17
    /// </summary>
    public static class DataTableExtension
    {
        #region 将DataTable转为实体

        private delegate List<T> TableToListDelegate<T>(DataTable table);//将Table转为List的委托

        #endregion 将DataTable转为实体

        /// <summary>
        /// 获取该DataTable里是否有数据
        /// </summary>
        /// <param name="table">目标table</param>
        /// <returns>有数据则返回true，否则返回false</returns>
        public static bool HasDataRow(this DataTable table)
        {
            return table?.Rows != null && table.Rows.Count != 0;
        }

        #region 将DataRow转换成对应的实体。

        private delegate T RowToEntityDelegate<out T>(DataRow row); //将DataRow转为Entity的委托

        #endregion 将DataRow转换成对应的实体。

        public static object To(this object @this, Type type)
        {
            if (@this == null) return null;
            var targetType = type;

            if (@this.GetType() == targetType)
            {
                return @this;
            }

            var converter = TypeDescriptor.GetConverter(@this);
            if (converter.CanConvertTo(targetType))
            {
                return converter.ConvertTo(@this, targetType);
            }

            converter = TypeDescriptor.GetConverter(targetType);
            if (converter.CanConvertFrom(@this.GetType()))
            {
                return converter.ConvertFrom(@this);
            }

            return @this == DBNull.Value ? null : @this;
        }
    }
}