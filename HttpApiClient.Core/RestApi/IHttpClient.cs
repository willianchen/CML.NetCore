using RestSharp;
using System;

namespace HttpApiClient.Core.Http
{
    public interface IHttpClient
    {
        /// <summary>
        /// 同步执行方法
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IRestResponse Execute(IRestRequest request);


        /// <summary>
        /// 同步执行方法
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="act"></param>
        /// <returns></returns>
        IRestResponse Execute(string resource, Method method, Action<IRestRequest> act = null);


        /// <summary>
        /// 同步执行方法
        /// </summary>
        /// <typeparam name="T">返回值</typeparam>
        /// <param name="request">请求参数</param>
        /// <returns></returns>
        T Execute<T>(IRestRequest request) where T : new();


        /// <summary>
        /// 同步执行方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="act"></param>
        /// <returns></returns>
        T Execute<T>(string resource, Method method, Action<IRestRequest> act = null) where T : new();


        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse> callback);

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <param name="resource">请求url</param>
        /// <param name="method">请求方式</param>
        /// <param name="act"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        RestRequestAsyncHandle ExecuteAsync(string resource, Method method, Action<IRestRequest> act = null, Action<IRestResponse> callback = null);


        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>> callback) where T : new();

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="act"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        RestRequestAsyncHandle ExecuteAsync<T>(string resource, Method method, Action<IRestRequest> act = null, Action<IRestResponse<T>> callback = null) where T : new();
    }
}
