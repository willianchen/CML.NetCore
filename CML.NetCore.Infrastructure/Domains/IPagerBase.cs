using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Domains
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IPageBase.cs
    /// 类属性：接口
    /// 类功能描述：分页
    /// 创建标识：cml 2018/2/8 15:09:56
    /// </summary>
    public interface IPagerBase
    {
        /// <summary>
        /// 页数，即第几页，从1开始
        /// </summary>
        int PageIndex { get; set; }
        /// <summary>
        /// 每页显示行数
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        int TotalCount { get; set; }
    }
}
