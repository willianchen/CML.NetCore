using System;

namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TimeElapsedInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：时间消耗信息
    /// 创建标识：yjq 2017/7/22 14:52:00
    /// </summary>
    public class TimeElapsedInfo
    {
        /// <summary>
        /// 消耗类型
        /// </summary>
        public TimeElapsedType TimeElapsedType { get; set; }

        /// <summary>
        /// 调用方法
        /// </summary>
        public string CallMemberName { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 消耗时间
        /// </summary>
        public double TimeElapsed { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime ExecuteTime { get; set; }
    }
}