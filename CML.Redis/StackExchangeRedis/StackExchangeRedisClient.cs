using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CML.Lib.Utils;
using CML.Redis.Serialization;
using StackExchange.Redis;
using CML.Lib.Extensions;
using System.Linq;

namespace CML.Redis.StackExchangeRedis
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：StackExchangeRedisClient.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：StackExchangeRedisClient
    /// 创建标识：cml 2018/3/14 16:52:03
    /// </summary>
    public sealed class StackExchangeRedisClient : IRedisClient
    {
        private readonly IDatabase _database;
        private readonly IRedisBinarySerializer _serializer;
        private readonly RedisConfig _redisConfig;
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public StackExchangeRedisClient(RedisConfig redisConfig, IRedisBinarySerializer serializer)
        {
            EnsureUtil.NotNull(redisConfig, "redisConfig");
            EnsureUtil.NotNull(serializer, "serializer");
            _redisConfig = redisConfig;
            _serializer = serializer;
            _database = ConnectionMultiplexerFactory.GetDatabase(_redisConfig);
            _connectionMultiplexer = ConnectionMultiplexerFactory.GetConnectionMultiplexer(_redisConfig);
        }

        private IDatabase Database
        {
            get { return _database; }
        }

        private ConnectionMultiplexer Connection
        {
            get { return _connectionMultiplexer; }
        }

        private IRedisBinarySerializer Serializer
        {
            get { return _serializer; }
        }
        private string SetPrefix(string key)
        {
            return _redisConfig.Prefix.IsNullOrEmptyWhiteSpace() ? key : $"{_redisConfig.Prefix}{_redisConfig.NamespaceSplitSymbol}{key}";
        }

        #region Hash

        /// <summary>
        /// Hash自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long HashDecrement(string key, string hashField, long value = 1)
        {
            key = SetPrefix(key);
            return Database.HashIncrement(key, hashField, value);

        }

        /// <summary>
        /// hash自增（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<long> HashDecrementAsync(string key, string hashField, long value = 1)
        {
            key = SetPrefix(key);
            return await Database.HashDecrementAsync(key, hashField, value);
        }

        /// <summary>
        /// 删除一个Hash键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public bool HashDelete(string key, string hashField)
        {
            key = SetPrefix(key);
            return Database.HashDelete(key, hashField);
        }

        /// <summary>
        /// 批量删除Hash键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public long HashDelete(string key, IEnumerable<string> hashFields)
        {
            key = SetPrefix(key);
            return Database.HashDelete(key, hashFields.Select(x => (RedisValue)x).ToArray());
        }

        /// <summary>
        /// 删除Hash一个键（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public async Task<bool> HashDeleteAsync(string key, string hashField)
        {
            key = SetPrefix(key);
            return await Database.HashDeleteAsync(key, hashField);
        }

        /// <summary>
        /// 批量删除Hash键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public async Task<long> HashDeleteAsync(string key, IEnumerable<string> hashFields)
        {
            key = SetPrefix(key);
            return await Database.HashDeleteAsync(key, hashFields.Select(x => (RedisValue)x).ToArray());
        }

        /// <summary>
        /// 判断是否存在Hash键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public bool HashExists(string key, string hashField)
        {
            key = SetPrefix(key);
            return Database.HashExists(key, hashField);
        }

        /// <summary>
        /// 判断是否存在Hash键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public async Task<bool> HashExistsAsync(string key, string hashField)
        {
            key = SetPrefix(key);
            return await Database.HashExistsAsync(key, hashField);
        }

        /// <summary>
        /// 获取Hash键
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public T HashGet<T>(string key, string hashField)
        {
            key = SetPrefix(key);
            var redisValue = Database.HashGet(key, hashField);
            return redisValue.HasValue ? Serializer.Deserialize<T>(redisValue) : default(T);
        }

        /// <summary>
        /// 获取Hash键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public Dictionary<string, T> HashGet<T>(string key, IEnumerable<string> hashFields)
        {
            var result = new Dictionary<string, T>();
            foreach (var hashField in hashFields)
            {
                var value = HashGet<T>(key, hashField);
                result.Add(key, value);
            }
            return result;
        }

        /// <summary>
        /// 获取全部Hash
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Dictionary<string, T> HashGetAll<T>(string key)
        {
            key = SetPrefix(key);
            return (Database
                    .HashGetAll(key))
                    .ToDictionary(
                        x => x.Name.ToString(),
                        x => Serializer.Deserialize<T>(x.Value),
                        StringComparer.Ordinal);
        }

        /// <summary>
        /// 获取全部Hash(异步)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, T>> HashGetAllAsync<T>(string key)
        {
            key = SetPrefix(key);
            return (await (Database
                    .HashGetAllAsync(key)))
                    .ToDictionary(
                        x => x.Name.ToString(),
                        x => Serializer.Deserialize<T>(x.Value),
                        StringComparer.Ordinal);
        }

        /// <summary>
        /// 获取Hash值（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public async Task<T> HashGetAsync<T>(string key, string hashField)
        {
            key = SetPrefix(key);
            var redisValue = await Database.HashGetAsync(key, hashField);
            return redisValue.HasValue ? Serializer.Deserialize<T>(redisValue) : default(T);
        }

        /// <summary>
        /// 批量获取Hash键值（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="hashFields"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, T>> HashGetAsync<T>(string key, IEnumerable<string> hashFields)
        {
            var result = new Dictionary<string, T>();
            foreach (var hashField in hashFields)
            {
                var value = await HashGetAsync<T>(key, hashField);
                result.Add(key, value);
            }
            return result;
        }

        /// <summary>
        /// hash自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long HashIncrement(string key, string hashField, long value = 1)
        {
            key = SetPrefix(key);
            return Database.HashIncrement(key, hashField, value);
        }

        /// <summary>
        /// Hash自增（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<long> HashIncrementAsync(string key, string hashField, long value = 1)
        {
            key = SetPrefix(key);
            return await Database.HashIncrementAsync(key, hashField, value);
        }

        /// <summary>
        ///  获取所有的Hash键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<string> HashKeys(string key)
        {
            key = SetPrefix(key);
            return Database.HashKeys(key).Select(x => x.ToString());
        }

        /// <summary>
        /// 获取Hash长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long HashLength(string key)
        {
            key = SetPrefix(key);
            return Database.HashLength(key);
        }

        /// <summary>
        /// 设置Hash键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HashSet<T>(string key, string hashField, T value)
        {
            key = SetPrefix(key);
            return Database.HashSet(key, hashField, Serializer.Serialize(value));
        }

        /// <summary>
        /// 批量设置Hash键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void HashSet<T>(string key, Dictionary<string, T> values)
        {
            key = SetPrefix(key);
            var entries = values.Select(kv => new HashEntry(kv.Key, Serializer.Serialize(kv.Value)));
            Database.HashSet(key, entries.ToArray());
        }

        /// <summary>
        /// 设置Hash键（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> HashSetAsync<T>(string key, string hashField, T value)
        {
            key = SetPrefix(key);
            return await Database.HashSetAsync(key, hashField, Serializer.Serialize(value));
        }

        /// <summary>
        /// 批量设置Hash键（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public async Task HashSetAsync<T>(string key, Dictionary<string, T> values)
        {
            key = SetPrefix(key);
            var entries = values.Select(kv => new HashEntry(kv.Key, Serializer.Serialize(kv.Value)));
            await Database.HashSetAsync(key, entries.ToArray());
        }

        /// <summary>
        /// 获取Hash值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<T> HashValues<T>(string key)
        {
            key = SetPrefix(key);
            return Database.HashValues(key).Select(x => Serializer.Deserialize<T>(x));
        }

        /// <summary>
        /// 获取Hash值（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> HashValuesAsync<T>(string key)
        {
            key = SetPrefix(key);
            return (await Database.HashValuesAsync(key)).Select(x => Serializer.Deserialize<T>(x));
        }

        #endregion Hash

        #region Key

        /// <summary>
        /// 获取Key数量
        /// </summary>
        /// <returns></returns>
        public int KeyCount()
        {
            return CalcuteKeyCount("*");
        }

        /// <summary>
        /// 判断Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            key = SetPrefix(key);
            return Database.KeyExists(key);
        }

        /// <summary>
        /// 判断Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> KeyExistsAsync(string key)
        {
            key = SetPrefix(key);
            return await Database.KeyExistsAsync(key);
        }

        /// <summary>
        /// 设置Key失效时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        public bool KeyExpire(string key, TimeSpan expire)
        {
            key = SetPrefix(key);
            return Database.KeyExpire(key, expire);
        }

        /// <summary>
        /// 设置Key失效时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool KeyExpire(string key, DateTime expiry)
        {
            key = SetPrefix(key);
            return Database.KeyExpire(key, expiry);
        }

        /// <summary>
        /// 设置Key失效时间（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        public async Task<bool> KeyExpireAsync(string key, TimeSpan expire)
        {
            key = SetPrefix(key);
            return await Database.KeyExpireAsync(key, expire);
        }

        /// <summary>
        /// 设置Key失效时间（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        public async Task<bool> KeyExpireAsync(string key, DateTime expire)
        {
            key = SetPrefix(key);
            return await Database.KeyExpireAsync(key, expire);
        }

        /// <summary>
        /// 删除Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyRemove(string key)
        {
            key = SetPrefix(key);
            return Database.KeyDelete(key);
        }

        /// <summary>
        /// 批量删除Key
        /// </summary>
        /// <param name="keys"></param>
        public void KeyRemoveAll(IEnumerable<string> keys)
        {
            foreach (var key in keys)
            {
                KeyRemove(key);
            }
        }

        /// <summary>
        /// 批量删除Key
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public async Task KeyRemoveAllAsync(IEnumerable<string> keys)
        {
            foreach (var key in keys)
            {
                await KeyRemoveAsync(key);
            }
        }

        /// <summary>
        /// 删除Key（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> KeyRemoveAsync(string key)
        {
            key = SetPrefix(key);
            return await Database.KeyDeleteAsync(key);
        }

        /// <summary>
        /// 查询Key
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public IEnumerable<string> KeySearch(string pattern)
        {
            throw new NotImplementedException();
        }

        #endregion Key

        #region List

        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public T ListLeftPop<T>(string key)
        {
            key = SetPrefix(key);
            var redisValue = Database.ListLeftPop(key);
            return redisValue.HasValue ? Serializer.Deserialize<T>(redisValue) : default(T);
        }

        /// <summary>
        /// 出栈（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> ListLeftPopAsync<T>(string key)
        {
            key = SetPrefix(key);
            var redisValue = await Database.ListLeftPopAsync(key);
            return redisValue.HasValue ? Serializer.Deserialize<T>(redisValue) : default(T);
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void ListLeftPush<T>(string key, T value)
        {
            key = SetPrefix(key);
            Database.ListLeftPush(key, Serializer.Serialize(value));
        }

        /// <summary>
        /// 入队（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<long> ListLeftPushAsync<T>(string key, T value)
        {
            key = SetPrefix(key);
            return await Database.ListLeftPushAsync(key, Serializer.Serialize(value));
        }

        /// <summary>
        /// 获取列表长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long ListLength(string key)
        {
            key = SetPrefix(key);
            return Database.ListLength(key);
        }

        /// <summary>
        /// 获取列表长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<long> ListLengthAsync(string key)
        {
            key = SetPrefix(key);
            return await Database.ListLengthAsync(key);
        }

        /// <summary>
        /// 获取指定key的List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> ListRange<T>(string key)
        {
            key = SetPrefix(key);
            return Database.ListRange(key).Select(x => Serializer.Deserialize<T>(x)).ToList();
        }

        /// <summary>
        /// 获取指定key的List（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<List<T>> ListRangeAsync<T>(string key)
        {
            key = SetPrefix(key);
            return (await Database.ListRangeAsync(key)).Select(x => Serializer.Deserialize<T>(x)).ToList();
        }

        /// <summary>
        /// 删除List指定项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void ListRemove<T>(string key, T value)
        {
            key = SetPrefix(key);
            Database.ListRemove(key, Serializer.Serialize(value));
        }

        /// <summary>
        /// 删除List指定项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<long> ListRemoveAsync<T>(string key, T value)
        {
            key = SetPrefix(key);
            return await Database.ListRemoveAsync(key, Serializer.Serialize(value));
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T ListRightPop<T>(string key)
        {
            key = SetPrefix(key);
            var rs = Database.ListRightPop(key);
            return rs.HasValue ? Serializer.Deserialize<T>(rs) : default(T);
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> ListRightPopAsync<T>(string key)
        {
            key = SetPrefix(key);
            var rs = await Database.ListRightPopAsync(key);
            return rs.HasValue ? Serializer.Deserialize<T>(rs) : default(T);
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void ListRightPush<T>(string key, T value)
        {
            key = SetPrefix(key);
            Database.ListRightPush(key, Serializer.Serialize(value));
        }

        /// <summary>
        /// 出栈（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<long> ListRightPushAsync<T>(string key, T value)
        {
            key = SetPrefix(key);
            return await Database.ListRightPushAsync(key, Serializer.Serialize(value));
        }
        #endregion List

        #region SortedSet

        /// <summary>
        /// 增加有序集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool SortedSetAdd<T>(string key, T value, double score)
        {
            key = SetPrefix(key);
            return Database.SortedSetAdd(key, Serializer.Serialize(value), score);
        }

        /// <summary>
        /// 增加有序集合（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public async Task<bool> SortedSetAddAsync<T>(string key, T value, double score)
        {
            key = SetPrefix(key);
            return await Database.SortedSetAddAsync(key, Serializer.Serialize(value), score);
        }

        /// <summary>
        /// 获取有序集合长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long SortedSetLength(string key)
        {
            key = SetPrefix(key);
            return Database.SortedSetLength(key);
        }

        /// <summary>
        /// 获取有序集合长度(异步)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<long> SortedSetLengthAsync(string key)
        {
            key = SetPrefix(key);
            return await Database.SortedSetLengthAsync(key);
        }

        /// <summary>
        /// 获取全部有序集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> SortedSetRangeAll<T>(string key)
        {
            key = SetPrefix(key);
            return Database.SortedSetRangeByRank(key).Select(x => Serializer.Deserialize<T>(x)).ToList();
        }

        /// <summary>
        /// 获取全部有序集合(异步)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<List<T>> SortedSetRangeAllAsync<T>(string key)
        {
            key = SetPrefix(key);
            return (await Database.SortedSetRangeByRankAsync(key)).Select(x => Serializer.Deserialize<T>(x)).ToList();
        }

        /// <summary>
        /// 删除有序集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SortedSetRemove<T>(string key, T value)
        {
            key = SetPrefix(key);
            return Database.SortedSetRemove(key, Serializer.Serialize(value));
        }

        /// <summary>
        /// 删除有序集合（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> SortedSetRemoveAsync<T>(string key, T value)
        {
            key = SetPrefix(key);
            return await Database.SortedSetRemoveAsync(key, Serializer.Serialize(value));
        }
        #endregion SortedSet

        #region String 

        /// <summary>
        /// String 自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long StringDecrement(string key, long value = 1)
        {
            key = SetPrefix(key);
            return Database.StringDecrement(key);
        }

        /// <summary>
        /// String 自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<long> StringDecrementAsync(string key, long value = 1)
        {
            key = SetPrefix(key);
            return await Database.StringDecrementAsync(key);
        }

        /// <summary>
        /// 获取指定Key的String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T StringGet<T>(string key)
        {
            key = SetPrefix(key);
            var rv = Database.StringGet(key);
            return rv.HasValue ? Serializer.Deserialize<T>(rv) : default(T);
        }

        /// <summary>
        /// 获取指定Key的String（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> StringGetAsync<T>(string key)
        {
            key = SetPrefix(key);
            var rv = await Database.StringGetAsync(key);
            return rv.HasValue ? Serializer.Deserialize<T>(rv) : default(T);
        }

        /// <summary>
        /// String 自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long StringIncrement(string key, long value = 1)
        {
            key = SetPrefix(key);
            return Database.StringIncrement(key, value);
        }

        /// <summary>
        /// String自增（异步）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<long> StringIncrementAsync(string key, long value = 1)
        {
            key = SetPrefix(key);
            return await Database.StringIncrementAsync(key, value);
        }

        /// <summary>
        /// 设置String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool StringSet<T>(string key, T value)
        {
            key = SetPrefix(key);
            return Database.StringSet(key, Serializer.Serialize(value));
        }

        /// <summary>
        /// 设置String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn">过期间隔</param>
        /// <returns></returns>
        public bool StringSet<T>(string key, T value, TimeSpan expiresIn)
        {
            key = SetPrefix(key);
            return Database.StringSet(key, Serializer.Serialize(value), expiresIn);
        }

        /// <summary>
        /// 设置String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresAt">过期时间</param>
        /// <returns></returns>
        public bool StringSet<T>(string key, T value, DateTimeOffset expiresAt)
        {
            key = SetPrefix(key);
            var expiration = expiresAt.Subtract(DateTimeOffset.Now);
            return Database.StringSet(key, Serializer.Serialize(value), expiration);
        }

        /// <summary>
        /// 批量设置String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool StringSetAll<T>(Dictionary<string, T> items)
        {
            var values = items.Select(m => new KeyValuePair<RedisKey, RedisValue>(SetPrefix(m.Key), Serializer.Serialize(m.Value))).ToArray();
            return Database.StringSet(values);
        }

        /// <summary>
        /// 批量设置String（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task<bool> StringSetAllAsync<T>(Dictionary<string, T> items)
        {
            var values = items.Select(m => new KeyValuePair<RedisKey, RedisValue>(SetPrefix(m.Key), Serializer.Serialize(m.Value))).ToArray();
            return await Database.StringSetAsync(values);
        }

        /// <summary>
        /// 设置String（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync<T>(string key, T value)
        {
            key = SetPrefix(key);
            return await Database.StringSetAsync(key, Serializer.Serialize(value));
        }

        /// <summary>
        /// 设置String（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn">失效时间间隔</param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync<T>(string key, T value, TimeSpan expiresIn)
        {
            key = SetPrefix(key);
            return await Database.StringSetAsync(key, Serializer.Serialize(value), expiresIn);
        }

        /// <summary>
        /// 设置String（异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresAt">失效时间</param>
        /// <returns></returns>
        public async Task<bool> StringSetAsync<T>(string key, T value, DateTimeOffset expiresAt)
        {
            key = SetPrefix(key);
            var expiration = expiresAt.Subtract(DateTimeOffset.Now);
            return await Database.StringSetAsync(key, Serializer.Serialize(value), expiration);
        }

        #endregion String

        #region Subscribe

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public long Publish<T>(string channel, T msg)
        {
            ISubscriber sub = Connection.GetSubscriber();
            return sub.Publish(channel, Serializer.Serialize(msg));
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="subChannel"></param>
        /// <param name="handler"></param>
        public void Subscribe(string subChannel, Action<RedisChannel, RedisValue> handler)
        {
            ISubscriber sub = Connection.GetSubscriber();
            sub.Subscribe(subChannel, (channel, message) =>
            {
                handler(channel, message);
            });
        }

        /// <summary>
        /// 解除订阅
        /// </summary>
        /// <param name="channel"></param>
        public void Unsubscribe(string channel)
        {
            ISubscriber sub = Connection.GetSubscriber();
            sub.Unsubscribe(channel);
        }

        /// <summary>
        /// 解除所有订阅
        /// </summary>
        public void UnsubscribeAll()
        {
            ISubscriber sub = Connection.GetSubscriber();
            sub.UnsubscribeAll();
        }
        #endregion Subscribe


        #region lock

        /// <summary>
        /// 获取一个锁
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns>成功返回true</returns>
        public bool LockTake<T>(string key, T value, TimeSpan expiry)
        {
            key = SetPrefix(key);
            var objBytes = Serializer.Serialize(value);
            return Database.LockTake(key, objBytes, expiry);
        }

        /// <summary>
        /// 异步获取一个锁
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns>成功返回true</returns>
        public async Task<bool> LockTakeAsync<T>(string key, T value, TimeSpan expiry)
        {
            key = SetPrefix(key);
            var objBytes = await Serializer.SerializeAsync(value);
            return await Database.LockTakeAsync(key, objBytes, expiry);
        }

        /// <summary>
        /// 释放一个锁
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">值</param>
        /// <returns>成功返回true</returns>
        public bool LockRelease<T>(string key, T value)
        {
            key = SetPrefix(key);
            var objBytes = Serializer.Serialize(value);
            return Database.LockRelease(key, objBytes);
        }

        /// <summary>
        /// 异步释放一个锁
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">值</param>
        /// <returns>成功返回true</returns>
        public async Task<bool> LockReleaseAsync<T>(string key, T value)
        {
            key = SetPrefix(key);
            var objBytes = await Serializer.SerializeAsync(value);
            return await Database.LockReleaseAsync(key, objBytes);
        }

        #endregion lock

        #region Public


        /// <summary>
        /// 清除key
        /// </summary>
        public async Task FlushDbAsync()
        {
            var endPoints = Database.Multiplexer.GetEndPoints();

            foreach (var endpoint in endPoints)
            {
                await Database.Multiplexer.GetServer(endpoint).FlushDatabaseAsync(Database.Database);
            }
        }


        /// <summary>
        /// 清除当前db的所有数据
        /// </summary>
        public void Clear()
        {
            DeleteKeyWithKeyPrefix("*");
        }

        /// <summary>
        /// 计算当前prefix开头的key总数
        /// </summary>
        /// <param name="prefix">key前缀</param>
        /// <returns></returns>
        private int CalcuteKeyCount(string prefix)
        {
            if (Database.IsNull())
            {
                return 0;
            }
            var retVal = Database.ScriptEvaluate("return table.getn(redis.call('keys', ARGV[1]))", values: new RedisValue[] { SetPrefix(prefix) });
            if (retVal.IsNull)
            {
                return 0;
            }
            return (int)retVal;
        }

        /// <summary>
        /// 删除以当前prefix开头的所有key缓存
        /// </summary>
        /// <param name="prefix">key前缀</param>
        private void DeleteKeyWithKeyPrefix(string prefix)
        {
            if (Database.IsNotNull())
            {
                Database.ScriptEvaluate(@"
                local keys = redis.call('keys', ARGV[1])
                for i=1,#keys,5000 do
                redis.call('del', unpack(keys, i, math.min(i+4999, #keys)))
                end", values: new RedisValue[] { SetPrefix(prefix) });
            }
        }

        #endregion Public
    }
}
