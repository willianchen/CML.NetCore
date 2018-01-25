using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CML.Lib.Json
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：NewtonsoftJsonSerializer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NewtonsoftJsonSerializer
    /// 创建标识：cml 2018/1/23 16:34:45
    /// </summary>
    public class NewtonsoftJsonSerializer : IJsonSerialize
    {
        public JsonSerializerSettings Settings { get; private set; }

        public JsonSerializerSettings IgnoreNullSettings { get; private set; }

        public NewtonsoftJsonSerializer()
        {
            Settings = new JsonSerializerSettings
            {
                ContractResolver = new CustomContractResolver(),
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
            IgnoreNullSettings = new JsonSerializerSettings
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ContractResolver = new CustomContractResolver(),
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
        }

        public string GetJsonByObj<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, IgnoreNullSettings);
        }

        public string GetJsonByObjIgnorreNull<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Settings);
        }

        public T GetObjByJson<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr, Settings);
        }
    }
    internal class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
            if (jsonProperty.Writable) return jsonProperty;
            var property = member as PropertyInfo;
            if (property == null) return jsonProperty;
            var hasPrivateSetter = property.GetSetMethod(true) != null;
            jsonProperty.Writable = hasPrivateSetter;
            return jsonProperty;
        }
    }
}
