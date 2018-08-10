using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpApiClient.Core.Http
{
    /// <summary>
    /// RestSharp构造器
    /// </summary>
    public class RestSharpClient : IHttpClient
    {
        /// <summary>
        /// Host
        /// </summary>
        private string _host { get; set; }

        private RestClient _restClient { get; set; }

        private IAuthenticator _authenticator { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host"></param>
        /// <param name="authenticator"></param>
        public RestSharpClient(string host, IAuthenticator authenticator = null)
        {
            if (string.IsNullOrWhiteSpace(host))
                throw new ArgumentNullException("host is null");

            _host = host;
            _authenticator = authenticator;

            _restClient = new RestClient(_host);
            if (_authenticator != null)
                _restClient.Authenticator = _authenticator;
        }

        /// <summary>
        /// 同步执行
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IRestResponse Execute(IRestRequest request)
        {
            var response = _restClient.Execute(request);
            return response;
        }

        /// <summary>
        /// 同步执行方法
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="act"></param>
        /// <returns></returns>
        public IRestResponse Execute(string resource, Method method, Action<IRestRequest> act = null)
        {
            IRestRequest request = new RestRequest(resource, method);
            act?.Invoke(request);
            return Execute(request);
        }

        /// <summary>
        /// 同步执行方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T Execute<T>(IRestRequest request) where T : new()
        {
            var response = _restClient.Execute<T>(request);
            return response.Data;
        }

        /// <summary>
        /// 同步执行方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="act"></param>
        /// <returns></returns>
        public T Execute<T>(string resource, Method method, Action<IRestRequest> act = null) where T : new()
        {
            IRestRequest request = new RestRequest(resource, method);
            act?.Invoke(request);
            return Execute<T>(request);
        }

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse> callback)
        {
            return _restClient.ExecuteAsync(request, callback);
        }

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="act"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync(string resource, Method method, Action<IRestRequest> act = null, Action<IRestResponse> callback = null)
        {
            IRestRequest request = new RestRequest(resource, method);
            act?.Invoke(request);
            return ExecuteAsync(request, callback);
        }

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>> callback) where T : new()
        {
            return _restClient.ExecuteAsync<T>(request, callback);
        }

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="act"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync<T>(string resource, Method method, Action<IRestRequest> act = null, Action<IRestResponse<T>> callback = null) where T : new()
        {
            IRestRequest request = new RestRequest(resource, method);
            act?.Invoke(request);
            return ExecuteAsync<T>(request, callback);
        }
    }
}
