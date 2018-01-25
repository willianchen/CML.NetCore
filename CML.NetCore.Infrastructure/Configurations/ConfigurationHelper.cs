using System;
using System.Collections.Generic;
using System.Text;
using CML.Lib.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;

namespace CML.Lib.Configurations
{
	/// <summary>
	/// Copyright (C) 2017 cml 版权所有。
	/// 类名：Configuration.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：Configuration
	/// 创建标识：cml 2018/1/23 14:53:37
	/// </summary>
    public class ConfigurationHelper
    {
        static ConfigurationHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(ProcessDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string ProcessDirectory
        {
            get
            {
#if NETSTANDARD1_3
                return AppContext.BaseDirectory;
#else
                return AppDomain.CurrentDomain.BaseDirectory;
#endif
            }
        }
        public static IConfigurationRoot Configuration { get; }
        public static void SetConsoleLogger() => InternalLoggerFactory.DefaultFactory.AddProvider(new ConsoleLoggerProvider((s, level) => true, false));
    }
}
