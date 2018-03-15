
using System.Threading.Tasks;
using CML.Lib.Extensions;

namespace CML.Redis.Serialization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RedisJsonBinarySerializer.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RedisJsonBinarySerializer
    /// 创建标识：cml 2018/3/14 17:11:03
    /// </summary>
    public class RedisJsonBinarySerializer : IRedisBinarySerializer
    {
        public RedisJsonBinarySerializer()
        {
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serializedObject">字符串</param>
        /// <returns>对象</returns>
        public virtual T Deserialize<T>(string serializedObject)
        {
            return serializedObject.ToObj<T>();
        }

        /// <summary>
        /// 异步反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="serializedObject">字符串</param>
        /// <returns>对象</returns>
        public virtual Task<T> DeserializeAsync<T>(string serializedObject)
        {
            return Task.FromResult(Deserialize<T>(serializedObject));
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="item">对象值</param>
        /// <returns>字符串</returns>
        public virtual string Serialize<T>(T item)
        {
            return item.ToJson();
        }

        /// <summary>
        /// 异步序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="item">对象值</param>
        /// <returns>字符串</returns>
        public virtual Task<string> SerializeAsync<T>(T item)
        {
            return Task.FromResult(Serialize(item));
        }
    }
}