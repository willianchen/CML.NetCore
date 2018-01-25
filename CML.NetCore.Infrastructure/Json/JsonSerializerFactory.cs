using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Json
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：JsonSerializerFactory.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：JsonSerializerFactory
    /// 创建标识：cml 2018/1/23 16:47:25
    /// </summary>
    public class JsonSerializerFactory
    {
        private static IJsonSerializeProvider _jsonSerializeProvider;

        public static IJsonSerializeProvider DefaultFactory()
        {
            var t = new NewtonsoftJsonSerializerProvider();
            return t;
        }


        public static IJsonSerialize GetInstance() => DefaultFactory().GetJsonSerialize();

    }
}
