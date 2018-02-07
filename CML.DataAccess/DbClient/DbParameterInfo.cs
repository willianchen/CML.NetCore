using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CML.DataAccess.DbClient
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DbParameterInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DbParameterInfo
    /// 创建标识：cml 2018/2/7 10:52:17
    /// </summary>
    public class DbParameterInfo
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public DbParameterInfo()
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="size">大小</param>
        /// <param name="direction">参数类型</param>
        /// <param name="scale">精度</param>
        public DbParameterInfo(string parameterName, object value, DbType? dbType, int? size, ParameterDirection? direction, byte? scale = null) : this()
        {
            ParameterName = parameterName;
            Value = value;
            if (dbType.HasValue)
            {
                DbType = dbType.Value;
            }
            if (size.HasValue)
            {
                Size = size.Value;
            }
            if (direction.HasValue)
            {
                ParameterDirection = direction.Value;
            }
            if (scale.HasValue)
            {
                Scale = scale.Value;
            }
        }

        /// <summary>
        /// 参数名字
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public ParameterDirection ParameterDirection { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 获取或设置所解析的 Value 的小数位数。
        /// </summary>
        public byte? Scale { get; set; }
    }
}