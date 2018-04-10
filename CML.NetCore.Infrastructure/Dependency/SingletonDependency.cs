using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Dependency
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：SingletonDependency.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：SingletonDependency
    /// 创建标识：cml 2018/4/9 16:55:38
    /// </summary>
    public static class SingletonDependency<T> where T : class
    {
        /// <summary>
        /// 获取单例对象
        /// </summary>
        public static T Instance => LazyInstance.Value;
        private static readonly Lazy<T> LazyInstance;

        static SingletonDependency()
        {
            LazyInstance = new Lazy<T>(() => ContainerManager.Resolve<T>(), true);
        }
    }
}
