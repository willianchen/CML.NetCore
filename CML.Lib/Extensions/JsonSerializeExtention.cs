using CML.Lib.JsonSerialize;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：JsonSerializeExtention.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：Json扩展类
    /// 创建标识：yjq 2017/7/12 18:11:02
    /// </summary>
    public static class JsonSerializeExtention
    {
        /// <summary>
        /// 将对象转换为json格式的字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj"></param>
        /// <returns>json格式的字符串</returns>
        public static string ToJson<T>(this T obj)
        {
            return NewtonsoftJsonSerializer.GetJsonByObj(obj);
        }

        /// <summary>
        /// 将对象转换为json格式的字符串(忽略null值)
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj"></param>
        /// <returns>json格式的字符串</returns>
        public static string ToJsonIgnoreNull<T>(this T obj)
        {
            return NewtonsoftJsonSerializer.GetJsonByObjIgnorreNull(obj);
        }

        /// <summary>
        /// 将json格式的字符串转为指定对象
        /// 如果json格式字符串格式不对则抛异常
        /// </summary>
        /// <typeparam name="T">要转换的对象类型</typeparam>
        /// <param name="json">json格式字符串</param>
        /// <returns>指定对象的实例</returns>
        public static T ToObjInfo<T>(this string json)
        {
            return NewtonsoftJsonSerializer.GetObjByJson<T>(json);
        }
    }
}