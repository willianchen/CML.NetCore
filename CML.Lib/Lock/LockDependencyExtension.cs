using CML.Lib.Dependency;

namespace CML.Lib.Lock
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：LockDependencyExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：LockDependcyExtension
    /// 创建标识：yjq 2017/9/21 22:43:41
    /// </summary>
    public static class LockDependencyExtension
    {
        /// <summary>
        /// 使用本地锁
        /// </summary>
        /// <param name="containerManager"></param>
        /// <returns></returns>
        public static ContainerManager UseLocalLock(this ContainerManager containerManager)
        {
            containerManager.RegisterType<ILock, LocalLock>();
            return containerManager;
        }
    }
}