using CML.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DictionaryExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：字典扩展类
    /// 创建标识：yjq 2017/7/15 21:07:17
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// 添加或者修改
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="data"></param>
        /// <param name="key">key</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Dictionary<string, T> AddOrUpdate<T>(this Dictionary<string, T> data, string key, T value)
        {
            if (data == null)
            {
                data = new Dictionary<string, T>(StringComparer.InvariantCultureIgnoreCase);
            }
            if (key.IsNotNullAndNotEmptyWhiteSpace())
            {
                if (data.ContainsKey(key))
                {
                    data[key] = value;
                }
                else
                {
                    data.Add(key, value);
                }
            }
            return data;
        }

        /// <summary>
        /// 对字典按键进行排序并进行拼接成字符串
        /// </summary>
        /// <param name="data">字典集合</param>
        /// <returns>拼接后的字符串</returns>
        public static string GetSortedContent<T>(this Dictionary<string, T> data)
        {
            if (data.Count > 0)
            {
                List<string> keys = data.Keys.ToList();
                keys.Sort();
                StringBuilder context = new StringBuilder();
                int currentIndex = 0;
                keys.ForEach(key =>
                {
                    if (currentIndex != 0)
                    {
                        context.Append("&");
                    }
                    context.Append(key).Append("=").Append(data[key]);
                    currentIndex++;
                });
                return context.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 将字典内容以key=value的形式进行拼接
        /// </summary>
        /// <param name="requestData">字典内容</param>
        /// <param name="charset">转换格式，默认为UTF-8</param>
        /// <returns>key=value的形式进行拼接的文本</returns>
        public static string ToRequestContent<T>(this Dictionary<string, T> requestData, string charset = null)
        {
            if (requestData == null || requestData.Count <= 0)
            {
                return string.Empty;
            }
            charset = charset ?? "UTF-8";
            StringBuilder query = new StringBuilder();
            bool hasParam = false;
            var orderedData = requestData.OrderBy(m => m.Key);
            foreach (var item in orderedData)
            {
                if (hasParam)
                {
                    query.Append("&");
                }
                else
                {
                    hasParam = true;
                }
                query.Append(item.Key).Append("=").Append(item.Value.ToSafeString().UrlEncode(charset));
            }
            return query.ToString();
        }

        /// <summary>
        /// 将对象转为字典，NULL时直接返回空字典
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDictionary(this object obj)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            if (obj == null)
            {
                return map;
            }
            var propertyList = PropertyUtil.GetPropertyInfos(obj);
            foreach (PropertyInfo p in propertyList)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, mi.Invoke(obj, new object[] { }));
                }
            }
            return map;
        }

        /// <summary>
        /// 根据键移除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public static Dictionary<string, T> RemoveKey<T>(this Dictionary<string, T> data, string key)
        {
            if (data == null) return data;
            if (data.ContainsKey(key))
            {
                data.Remove(key);
            }
            return data;
        }
    }
}