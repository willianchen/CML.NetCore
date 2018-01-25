using System.ComponentModel;

namespace CML.Lib.Result
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：OperateState.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：操作状态枚举
    /// 创建标识：yjq 2017/7/15 14:22:43
    /// </summary>
    public enum OperateState
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        [Description("操作成功")]
        Success = 10000,

        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("参数错误")]
        ParamError = 20000,

        /// <summary>
        /// 操作失败
        /// </summary>
        [Description("操作失败")]
        Failed = 90000
    }
}