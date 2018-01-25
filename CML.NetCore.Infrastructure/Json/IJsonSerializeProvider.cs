using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Json
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IJsonSerializeProvider.cs
    /// 类属性：接口
    /// 类功能描述：IJsonSerializeProvider
    /// 创建标识：cml 2018/1/23 16:54:34
    /// </summary>
    public interface IJsonSerializeProvider
    {
        IJsonSerialize GetJsonSerialize();
    }
}
