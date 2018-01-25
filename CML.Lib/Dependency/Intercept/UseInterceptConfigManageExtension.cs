namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：UseInterceptConfigManageExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：使用AOP扩展类
    /// 创建标识：yjq 2017/7/22 14:59:23
    /// </summary>
    public static class UseInterceptConfigManageExtension
    {
        /// <summary>
        /// 使用时间监控消耗
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ContainerManager UseTimeElapsedStatistic(this ContainerManager configuration)
        {
            configuration.RegisterType(typeof(TimeElapsedStatistic), lifeStyle: LifeStyle.PerLifetimeScope);
            configuration.RegisterType(typeof(CacheStatisticIntercept), lifeStyle: LifeStyle.Transient);
            configuration.RegisterType(typeof(HttpStatisticIntercept), lifeStyle: LifeStyle.Transient);
            configuration.RegisterType(typeof(MQStatisticIntercept), lifeStyle: LifeStyle.Transient);
            configuration.RegisterType(typeof(NoSqlStatisticIntercept), lifeStyle: LifeStyle.Transient);
            configuration.RegisterType(typeof(OtherStatisticIntercept), lifeStyle: LifeStyle.Transient);
            configuration.RegisterType(typeof(RpcStatisticIntercept), lifeStyle: LifeStyle.Transient);
            configuration.RegisterType(typeof(SqlStatisticIntercept), lifeStyle: LifeStyle.Transient);
            return configuration;
        }
    }
}