using EmitMapper;
using EmitMapper.MappingConfiguration;

namespace CML.Lib.Emits
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MapperUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：emitMapper转换帮助类
    /// 创建标识：yjq 2017/6/19 15:49:52
    /// </summary>
    public static class MapperUtil
    {
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="TFrom">来源类型</typeparam>
        /// <typeparam name="TTo">目标类型</typeparam>
        /// <param name="fromValue">来源值</param>
        /// <returns>目标类型值</returns>
        //internal static TTo MapperTo<TFrom, TTo>(TFrom fromValue)
        //{
        //    return GetMapper<TFrom, TTo>().Map(fromValue);
        //}

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="TFrom">来源类型</typeparam>
        /// <typeparam name="TTo">目标类型</typeparam>
        /// <param name="fromValue">来源值</param>
        /// <returns>目标类型值</returns>
        internal static TTo MapperTo<TFrom, TTo>(TFrom fromValue)
        {
            var objectMapper = ObjectMapperManager.DefaultInstance.GetMapperImpl(fromValue.GetType(), typeof(TTo), DefaultMapConfig.Instance);
            return (TTo)objectMapper.Map(fromValue);
        }

        internal static TTo MapperTo<TTo>(object fromValue)
        {
            var objectMapper = ObjectMapperManager.DefaultInstance.GetMapperImpl(fromValue.GetType(), typeof(TTo), DefaultMapConfig.Instance);
            return (TTo)objectMapper.Map(fromValue);
        }

        /// <summary>
        /// 获取类型转换方法
        /// </summary>
        /// <typeparam name="TFrom">来源类型</typeparam>
        /// <typeparam name="TTo">目标类型</typeparam>
        /// <returns>类型转换方法</returns>
        public static ObjectsMapper<TFrom, TTo> GetMapper<TFrom, TTo>()
        {
            return ObjectMapperManager.DefaultInstance.GetMapper<TFrom, TTo>();
        }

        /// <summary>
        /// 获取类型转换方法
        /// </summary>
        /// <typeparam name="TFrom">来源类型</typeparam>
        /// <typeparam name="TTo">目标类型</typeparam>
        /// <param name="mappingConfigurator">匹配配置</param>
        /// <returns>类型转换方法</returns>
        public static ObjectsMapper<TFrom, TTo> GetMapper<TFrom, TTo>(IMappingConfigurator mappingConfigurator)
        {
            return ObjectMapperManager.DefaultInstance.GetMapper<TFrom, TTo>(mappingConfigurator);
        }
    }
}