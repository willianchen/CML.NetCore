using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DatabaseConnection.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DatabaseConnection
    /// 创建标识：cml 2018/2/6 14:58:30
    /// </summary>
    public struct DatabaseConnection
    {
        private string _connectionString;
        private DatabaseType _databaseType;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType
        {
            get
            {
                return _databaseType;
            }
            set
            {
                _databaseType = value;
            }
        }
    }
}