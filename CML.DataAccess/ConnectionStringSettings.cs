using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using CML.Lib.Utils;

namespace CML.DataAccess
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DatabaseSetting.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DatabaseSetting
    /// 创建标识：cml 2018/2/6 15:45:23
    /// </summary>
    public class ConnectionStringSettings
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProviderName { get; set; }


        public ConnectionStringSettings(IConfiguration configuration)
        {
            EnsureUtil.NotNull(configuration, "数据库连接");
            this.ConnectionString = configuration["ConnectionString"];
            this.ProviderName = configuration["ProviderName"];
        }
    }
}
