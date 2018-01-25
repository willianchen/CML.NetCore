namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MQStatisticIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MQ统计AOP
    /// 创建标识：yjq 2017/7/22 15:15:15
    /// </summary>
    public class MQStatisticIntercept : BaseMonitorIntercept
    {
        public MQStatisticIntercept(TimeElapsedStatistic timeElapsedStatistic) : base(timeElapsedStatistic)
        {
        }

        public override TimeElapsedType TimeElapsedType
        {
            get
            {
                return TimeElapsedType.MQ;
            }
        }
    }
}