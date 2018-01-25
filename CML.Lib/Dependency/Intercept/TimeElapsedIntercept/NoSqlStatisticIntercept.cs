using Castle.DynamicProxy;

namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：NoSqlStatisticIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NoSql统计AOP
    /// 创建标识：yjq 2017/7/22 15:05:35
    /// </summary>
    public class NoSqlStatisticIntercept : BaseMonitorIntercept
    {

        public NoSqlStatisticIntercept(TimeElapsedStatistic timeElapsedStatistic) : base(timeElapsedStatistic)
        {
        }

        public override TimeElapsedType TimeElapsedType
        {
            get
            {
                return TimeElapsedType.NoSql;
            }
        }
    }
}