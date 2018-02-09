using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CML.Lib.Domains
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：PagerList.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：PagerList
    /// 创建标识：cml 2018/2/8 15:27:46
    /// </summary>
    public class PagerList<T> : IPagerBase
    {
        /// <summary>
        /// 初始化分页集合
        /// <param name="data">数据</param>
        /// </summary>
        public PagerList(IEnumerable<T> data) : this(0, data)
        {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="totalCount">总行数</param>
        /// <param name="data">数据</param>
        public PagerList(int totalCount, IEnumerable<T> data)
            : this(1, 30, totalCount, data)
        {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="totalCount">总行数</param>
        /// <param name="data">数据列表</param>
        public PagerList(int pageIndex, int pageSize, int totalCount, IEnumerable<T> data)
        {
            Data = new List<T>();
            var pager = new Pager(pageIndex, pageSize, totalCount);
            TotalCount = pager.TotalCount;
            PageCount = pager.GetPageCount();
            PageIndex = pager.PageIndex;
            PageSize = pager.PageSize;
            Data = data ?? new List<T>();
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="pager">查询对象</param>
        public PagerList(IPager pager)
            : this(pager.PageIndex, pager.PageSize, pager.TotalCount, null)
        {
        }

        /// <summary>
        /// 页索引，即第几页，从1开始
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public IEnumerable<T> Data { get; }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">索引</param>
        public T this[int index]
        {
            get => Data.ToList()[index];
            set => Data.ToList()[index] = value;
        }

        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="item">元素</param>
        public void Add(T item)
        {
            Data.ToList().Add(item);
        }

        /// <summary>
        /// 添加元素集合
        /// </summary>
        /// <param name="collection">元素集合</param>
        public void AddRange(IEnumerable<T> collection)
        {
            Data.ToList().AddRange(collection);
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            Data.ToList().Clear();
        }

        /// <summary>
        /// 转换分页集合的元素类型
        /// </summary>
        /// <typeparam name="TResult">目标元素类型</typeparam>
        /// <param name="converter">转换方法</param>
        public PagerList<TResult> Convert<TResult>(Func<T, TResult> converter)
        {
            var result = new PagerList<TResult>(PageIndex, PageSize, TotalCount, null);
            result.AddRange(this.Data.Select(converter));
            return result;
        }
    }
}
