using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Domains
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IPage.cs
    /// 类属性：接口
    /// 类功能描述：IPage
    /// 创建标识：cml 2018/2/8 14:18:20
    /// </summary>
    public interface IPager : IPagerBase
    {
        /// <summary>
        /// 获取总页数
        /// </summary>
        int GetPageCount();
        /// <summary>
        /// 获取跳过的行数
        /// </summary>
        int GetSkipCount();
        /// <summary>
        /// 排序条件
        /// </summary>
        string Order { get; set; }
        /// <summary>
        /// 获取起始行数
        /// </summary>
        int GetStartNumber();
        /// <summary>
        /// 获取结束行数
        /// </summary>
        int GetEndNumber();
    }
}