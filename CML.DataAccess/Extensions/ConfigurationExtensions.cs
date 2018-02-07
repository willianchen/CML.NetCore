using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ConfigurationExtensions.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ConfigurationExtensions
    /// 创建标识：cml 2018/2/6 15:40:54
    /// </summary>
    public static class ConfigurationExtensions
    {

        public static ConnectionStringSettings GetConnectionSettings(this IConfiguration configuration, string name)
        {
            if (configuration == null)
                return (ConnectionStringSettings)null;

            IConfigurationSection section = configuration.GetSection("ConnectionStrings");
            if (section == null)
                return (ConnectionStringSettings)null;
            ConnectionStringSettings settings = new ConnectionStringSettings(section.GetSection(name));
            return settings;
        }
    }
}
