using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DatabaseType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DatabaseType
    /// 创建标识：cml 2018/2/6 14:57:33
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// MSSQLServer
        /// </summary>
        MSSQLServer = 1,

        /// <summary>
        /// Oracle
        /// </summary>
        Oracle = 2,

        /// <summary>
        /// MySql
        /// </summary>
        MySql = 3,

        /// <summary>
        /// PostgreSqlClient
        /// </summary>
        PostgreSqlClient = 4
    }
}