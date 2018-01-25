namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：MapperExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：类型转换扩展类
    /// 创建标识：yjq 2017/6/19 15:57:42
    /// </summary>
    public static class MapperExtension
    {
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="TFrom">来源类型</typeparam>
        /// <typeparam name="TTo">目标类型</typeparam>
        /// <param name="fromValue">来源值</param>
        /// <returns>目标类型值</returns>
        public static TTo MapperTo<TFrom, TTo>(this TFrom fromValue)
        {
            return Emits.MapperUtil.MapperTo<TFrom, TTo>(fromValue);
        }

        /// <summary>
        /// 类型转换 fromValue最好是引用类型，非引用类型请使用<cref>MapperExtension.MapperTo<TFrom, TTo>(this TFrom fromValue)</cref>
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromValue">来源值</param>
        /// <returns>目标类型值</returns>
        public static TTo MapperTo<TTo>(this object fromValue)
        {
            return Emits.MapperUtil.MapperTo<TTo>(fromValue);
        }
    }
}