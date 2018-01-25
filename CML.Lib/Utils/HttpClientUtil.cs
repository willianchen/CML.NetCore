using CML.Lib.Configurations;
using CML.Lib.Extensions;
using CML.Lib.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：HttpClientUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：httpClient帮助类
    /// 创建标识：cq 2017/8/29 14:15:51
    /// </summary>
    public static class HttpClientUtil
    {
        private static ConcurrentDictionary<string, HttpClient> _ClientConnection = new ConcurrentDictionary<string, HttpClient>();

        /// <summary>
        /// 获取长连接
        /// </summary>
        /// <param name="baseAddressUrl">基础地址</param>
        /// <returns></returns>
        public static HttpClient GetLongClient(string baseAddressUrl)
        {
            return _ClientConnection.GetValue(baseAddressUrl, () =>
            {
                var _httpClient = new HttpClient() { BaseAddress = new Uri(baseAddressUrl) };
                _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                //ExceptionUtil.LogException(() =>
                //{
                //    _httpClient.SendAsync(new HttpRequestMessage
                //    {
                //        Method = new HttpMethod("HEAD"),
                //        RequestUri = new Uri(baseAddressUrl + "/")
                //    }).Result.EnsureSuccessStatusCode();
                //});

                return _httpClient;
            });
        }

        /// <summary>
        /// 发送一次post请求
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <typeparam name="TData">发送内容</typeparam>
        /// <param name="client"></param>
        /// <param name="data">请求数据</param>
        /// <param name="requestUrl">请求地址</param>
        /// <returns></returns>
        public static TResult Post<TResult, TData>(this HttpClient client, TData data, string requestUrl)
        {
            return ExceptionUtil.LogException(() =>
            {
                var postContent = new FormUrlEncodedContent(data.ToDictionary().Select(m => new KeyValuePair<string, string>(m.Key, m.Value.ToSafeString())));
                LogUtil.Debug($"http Url{requestUrl} 请求内容{data.ToJson()}");
                var responseContent = client.PostAsync(requestUrl, postContent).Result.Content.ReadAsStringAsync().Result;
                LogUtil.Debug($"http Url{requestUrl} 响应内容{responseContent}");
                return responseContent.ToObjInfo<TResult>();
            }, defaultValue: default(TResult), memberName: "HttpClientUtil-Post");
        }

        /// <summary>
        /// 使用http长连接
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Configuration UseLongHttpClient(this Configuration config)
        {
            config.AddUnInStallAction(() =>
            {
                foreach (var key in _ClientConnection.Keys)
                {
                    HttpClient client = null;
                    if (_ClientConnection.TryRemove(key, out client))
                    {
                        client?.Dispose();
                    }
                }
            });
            return config;
        }
    }
}