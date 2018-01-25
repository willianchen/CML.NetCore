using CML.Lib.Dependency;
using CML.Lib.Logger.NLogger;

namespace CML.Lib.Logger
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：LoggerRedisterExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/11/16 9:57:13
    /// </summary>
    public static class LoggerRegisterExtension
    {
        /// <summary>
        /// 使用Nlog
        /// </summary>
        /// <param name="containerManager"></param>
        /// <returns></returns>
        public static ContainerManager UseNlog(this ContainerManager containerManager)
        {
            containerManager.RegisterType<ILoggerFactory, NLoggerFactory>();
            return containerManager;
        }
    }
}