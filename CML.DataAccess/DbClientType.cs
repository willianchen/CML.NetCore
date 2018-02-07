using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DbClientType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DbClientType
    /// 创建标识：cml 2018/2/6 14:59:52
    /// </summary>
    internal static class DbClientType
    {
        /// <summary>
        /// sqlservcer的连接类型
        /// </summary>
        public const string DB_CLINET_MSSQL = "System.Data.SqlClient";

        /// <summary>
        /// Oracle的连接类型
        /// </summary>
        public const string DB_CLINET_ORACLE = "System.Data.OracleClien";

        /// <summary>
        /// MySql的连接类型
        /// </summary>
        public const string DB_CLINET_MYSQL = "MySql.Data.MySqlClient";

        /// <summary>
        /// PostgreSql的连接类型
        /// </summary>
        public const string DB_CLINET_POSTGRESQL = "MySql.Data.PostgreSqlClient";
    }
}