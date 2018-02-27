using CML.DataAccess.DbClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IDataAccessFactory.cs
    /// 类属性：接口
    /// 类功能描述：IDataAccessFactory
    /// 创建标识：cml 2018/2/27 13:33:16
    /// </summary>
    public interface IDataAccessFactory : IDisposable
    {
        /// <summary>
        /// 获取一个数据操作类
        /// </summary>
        /// <param name="configName">配置文件名字</param>
        /// <param name="isWriter">是否为写连接，不是则为读连接，默认为写连接</param>
        /// <returns>数据操作</returns>
        IDataAccess GetDataAccess(string configName, bool isWriter = true);
    }
}
