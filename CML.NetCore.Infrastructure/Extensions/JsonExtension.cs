using System.Runtime.InteropServices.ComTypes;
using CML.Lib.Json;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：JsonExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：JsonExtension
    /// 创建标识：cml 2018/2/5 17:14:23
    /// </summary>
    public static class JsonExtension
    {
        private static readonly IJsonSerialize Json = JsonSerializerFactory.GetInstance();

        public static string ToJson(this object obj)
        {
            return Json.GetJsonByObj(obj);
        }

        public static T ToObj<T>(this string obj)
        {
            return Json.GetObjByJson<T>(obj);
        }
    }
}
