using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Json
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IJsonSerialize.cs
    /// 类属性：接口
    /// 类功能描述：IJsonSerialize
    /// 创建标识：cml 2018/1/23 16:32:56
    /// </summary>
    public interface IJsonSerialize
    {
        T GetObjByJson<T>(string jsonStr);

        string GetJsonByObj<T>(T obj);

        string GetJsonByObjIgnorreNull<T>(T obj);
    }
}
