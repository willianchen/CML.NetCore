using System;
using System.Collections.Generic;
using System.Text;
using CML.DataAccess.Extensions;
using CML.Lib.Configurations;
using Microsoft.Extensions.Configuration;

namespace CML.DataAccess
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DBSettings.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DBSettings
    /// 创建标识：cml 2018/2/6 15:00:40
    /// </summary>
    internal static class DBSettings
    {
        /// <summary>
        /// 根据配置名字获取数据库属性信息
        /// </summary>
        /// <param name="name">配置名字</param>
        /// <returns>数据库属性信息</returns>
        public static DatabaseProperty GetDatabaseProperty(string name)
        {
            DatabaseConnection reader = GetDbConnection(name + ".Reader");
            DatabaseConnection writer = GetDbConnection(name + ".Writer");
            return new DatabaseProperty(reader, writer);
        }

        /// <summary>
        /// 根据配置名字获取连接信息
        /// </summary>
        /// <param name="connectionSettingName">配置名字</param>
        /// <returns>连接信息</returns>
        private static DatabaseConnection GetDbConnection(string connectionSettingName)
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationHelper.Configuration.GetConnectionSettings(connectionSettingName);
            DatabaseConnection dbConnection = default(DatabaseConnection);
            dbConnection.DatabaseType = DatabaseType.MSSQLServer;
            if (connectionStringSettings == null)
            {
                dbConnection.ConnectionString = string.Empty;
            }
            else
            {
                dbConnection.ConnectionString = connectionStringSettings.ConnectionString;
                dbConnection.DatabaseType = GetDbType(connectionStringSettings.ProviderName);
            }
            return dbConnection;
        }

        /// <summary>
        /// 根据提供程序名称属性获取对应数据库类型
        /// </summary>
        /// <param name="providerName">提供程序名称属性</param>
        /// <returns>数据库类型</returns>
        private static DatabaseType GetDbType(string providerName)
        {
            DatabaseType dataType = default(DatabaseType);
            switch (providerName)
            {
                case DbClientType.DB_CLINET_MSSQL:
                    dataType = DatabaseType.MSSQLServer;
                    break;

                case DbClientType.DB_CLINET_MYSQL:
                    dataType = DatabaseType.MySql;
                    break;

                case DbClientType.DB_CLINET_ORACLE:
                    dataType = DatabaseType.Oracle;
                    break;

                case DbClientType.DB_CLINET_POSTGRESQL:
                    dataType = DatabaseType.PostgreSqlClient;
                    break;

                default:
                    throw new ArgumentNullException(providerName, "未找到该数据库类型.");
            }
            return dataType;
        }
    }
}