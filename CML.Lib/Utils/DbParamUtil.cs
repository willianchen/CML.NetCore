using CML.Lib.Emits;
using System;
using System.Collections.Generic;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DbParamUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：sql参数工具类
    /// 创建标识：yjq 2017/7/12 18:42:30
    /// </summary>
    public static class DbParamUtil
    {
        /// <summary>
        /// 将object转为SqlParameter List
        /// </summary>
        /// <param name="obj">要转换的值</param>
        /// <param name="prefix">参数前缀</param>
        /// <returns>SqlParameter List</returns>
        public static List<SqlParameter> ToSqlParam(this object obj, string prefix = null)
        {
            return obj.ToDbParam<SqlParameter>("@", prefix);
        }

        /// <summary>
        /// 将object转为DbParameterList
        /// </summary>
        /// <typeparam name="TParam">DbParameter</typeparam>
        /// <param name="obj">要转换的值</param>
        /// <param name="sign">参数符号</param>
        /// <param name="prefix">参数前缀</param>
        /// <returns>DbParameterList</returns>
        public static List<TParam> ToDbParam<TParam>(this object obj, string sign, string prefix) //where TParam : DbParameter
        {
            if (obj == null) return default(List<TParam>);
            var convertMethod = DynamicMethodUtil.GetObjectToParamListMethod<TParam>(obj.GetType());
            var action = (Func<object, string, string, List<TParam>>)convertMethod.CreateDelegate(typeof(Func<object, string, string, List<TParam>>));
            return action(obj, sign, prefix);
        }
    }
}