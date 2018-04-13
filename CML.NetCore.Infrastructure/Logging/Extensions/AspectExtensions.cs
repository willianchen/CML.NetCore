using AspectCore.DynamicProxy.Parameters;
using CML.Lib.Extensions;
using CML.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CML.Lib.Logging.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：Extensions.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AOP拓展
    /// 创建标识：cml 2018/4/13 16:27:03
    /// </summary>
    /// <summary>
    /// AOP扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 添加日志参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="log">参数</param>
        public static void AppendTo(this Parameter parameter, StringBuilder builder)
        {
            builder.AppendFormat($"参数类型：{parameter.ParameterInfo.ParameterType.FullName},参数名称：{ parameter.Name} 参数值：{GetParameterValue(parameter)}");
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        private static string GetParameterValue(Parameter parameter)
        {
            if (TypeUtil.IsArrayOrCollection(parameter.RawType) == false)
                return parameter.Value.ToString();
            if (!(parameter.Value is IEnumerable<object> list))
                return parameter.Value.ToString();
            return list.Select(t => t.ToString()).ToJoin();
        }
    }
}
