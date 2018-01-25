using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Json
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：NewtonsoftJsonSerializerProvider.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NewtonsoftJsonSerializerProvider
    /// 创建标识：cml 2018/1/23 16:55:39
    /// </summary>
    public class NewtonsoftJsonSerializerProvider : IJsonSerializeProvider
    {
        public IJsonSerialize GetJsonSerialize() => new NewtonsoftJsonSerializer();
     
    }
}
