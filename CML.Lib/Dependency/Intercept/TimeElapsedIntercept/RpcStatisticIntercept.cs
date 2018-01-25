namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RpcStatisticIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Rpc统计AOP
    /// 创建标识：yjq 2017/7/22 15:17:55
    /// </summary>
    public class RpcStatisticIntercept : BaseMonitorIntercept
    {
        public RpcStatisticIntercept(TimeElapsedStatistic timeElapsedStatistic) : base(timeElapsedStatistic)
        {
        }

        public override TimeElapsedType TimeElapsedType
        {
            get
            {
                return TimeElapsedType.RPC;
            }
        }
    }
}