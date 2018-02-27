using CML.Lib.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.RegisterExtension
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DataAccessDependencyExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DataAccessDependencyExtension
    /// 创建标识：cml 2018/2/27 15:52:14
    /// </summary>
    public static class DataAccessDependencyExtension
    {
        /// <summary>
        /// 使用数据库
        /// </summary>
        /// <param name="containerManager"></param>
        /// <returns></returns>
        public static ContainerManager UseDataAccess(this ContainerManager containerManager)
        {
            containerManager.RegisterType<IDataAccessFactory, DataAccessFactory>(lifeStyle: LifeStyle.PerLifetimeScope);
            return containerManager;
        }
    }
}