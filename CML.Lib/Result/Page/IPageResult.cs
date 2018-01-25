using System.Collections.Generic;

namespace CML.Lib.Result
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IPageResult.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IPageResult接口
    /// 创建标识：yjq 2017/7/14 20:21:02
    /// </summary>
    public interface IPageResult
    {
        /// <summary>
        /// 总数量
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// 总页数
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// 当前页面
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// 页长
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 当前最小位置
        /// </summary>
        int CurrentMinPosition { get; }

        /// <summary>
        /// 当前最大位置
        /// </summary>
        int CurrentMaxPosition { get; }
    }

    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public interface IPageResult<T> : IPageResult, IEnumerable<T>
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        IEnumerable<T> Data { get; }
    }
}