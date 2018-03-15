using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CML.Redis.Serialization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：IRedisBinarySerializer.cs
    /// 类属性：接口
    /// 类功能描述：IRedisBinarySerializer
    /// 创建标识：cml 2018/3/14 17:10:28
    /// </summary>
    public interface IRedisBinarySerializer
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serializedObject">字符串</param>
        /// <returns>对象</returns>
        T Deserialize<T>(string serializedObject);

        /// <summary>
        /// 异步反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serializedObject">字符串</param>
        /// <returns>对象</returns>
        Task<T> DeserializeAsync<T>(string serializedObject);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="item">对象值</param>
        /// <returns>字符串</returns>
		string Serialize<T>(T item);

        /// <summary>
        /// 异步序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="item">对象值</param>
        /// <returns>字符串</returns>
        Task<string> SerializeAsync<T>(T item);
    }
}