using System.ComponentModel;

namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TimeElapsedType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：时间消耗类型
    /// 创建标识：yjq 2017/7/22 14:50:01
    /// </summary>
    public enum TimeElapsedType
    {
        /// <summary>
        /// NoSql
        /// </summary>
        [Description("NoSql")]
        NoSql = 1,

        /// <summary>
        /// Cache
        /// </summary>
        [Description("Cache")]
        Cache = 2,

        /// <summary>
        /// Sql
        /// </summary>
        [Description("Sql")]
        Sql = 3,

        /// <summary>
        /// MQ
        /// </summary>
        [Description("MQ")]
        MQ = 4,

        /// <summary>
        /// HTTP
        /// </summary>
        [Description("HTTP")]
        HTTP = 5,

        /// <summary>
        /// RPC
        /// </summary>
        [Description("RPC")]
        RPC = 6,

        /// <summary>
        /// 其它
        /// </summary>
        [Description("其它")]
        Other = 7,
    }
}