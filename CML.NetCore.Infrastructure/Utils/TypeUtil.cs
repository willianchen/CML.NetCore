using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：TypeUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：TypeUtil
    /// 创建标识：cml 2018/2/7 13:46:47
    /// </summary>
    public static class TypeUtil
    {
        /// <summary>
        /// 判断类型是否为集合或者数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsArrayOrCollection(this Type type)
        {
            if (type == null) return false;
            if (type.IsArray)
            {
                return true;
            }

            if (type.IsGenericType)
            {
                var genericTypeDefinition = type.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(IEnumerable<>) || genericTypeDefinition == typeof(IList<>) ||
                    genericTypeDefinition == typeof(List<>) || genericTypeDefinition == typeof(IEnumerator<>))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取指定类型属性值,假如该类型是数组、泛型，则获取他的表示泛型类型的类型实参或泛型类型定义的类型
        /// </summary>
        /// <typeparam name="T">属性类型</typeparam>
        /// <param name="type">要获取的类型</param>
        /// <returns>属性类型的实例</returns>
        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            if (type == null) return default(T);
            if (type.IsArray || type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }

            return Attribute.GetCustomAttribute(type, typeof(T)) as T;
        }
    }
}