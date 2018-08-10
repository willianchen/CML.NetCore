using HttpApiClient.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpApiClient.Core
{
    public class HttpApiConfig : IDisposable
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private IHttpClient httpClient;

        /// <summary>
        /// 同步锁
        /// </summary>
        private readonly object syncRoot = new object();


        /// <summary>
        /// 获取HttpClient实例
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        public IHttpClient HttpClient
        {
            get => this.GetHttpClientSafeSync();
        }

        /// <summary>
        /// 以同步安全方式获取IHttpClient实例
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <returns></returns>
        private IHttpClient GetHttpClientSafeSync()
        {
            lock (this.syncRoot)
            {
                if (this.IsDisposed == true)
                {
                    throw new ObjectDisposedException(this.GetType().Name);
                }

                if (this.httpClient == null)
                {
                    this.httpClient = new RestSharpClient(HttpHost.ToString());
                }
                return this.httpClient;
            }
        }

        /// <summary>
        /// 获取或设置Http服务完整主机域名
        /// 例如http://www.webapiclient.com
        /// 设置了HttpHost值，HttpHostAttribute将失效  
        /// </summary>
        public Uri HttpHost { get; set; }

        /// <summary>
        /// 实例化Host
        /// </summary>
        /// <param name="host"></param>
        public HttpApiConfig(string host) : this(new RestSharpClient(host))
        {
            HttpHost = new Uri(host);
        }


        /// <summary>
        /// Http接口的配置项   
        /// </summary>
        public HttpApiConfig() :
            this(default(IHttpClient))
        {
        }

        /// <summary>
        /// Http接口的配置项   
        /// </summary>
        /// <param name="client">客户端对象</param>
        public HttpApiConfig(IHttpClient client)
        {
            this.httpClient = client;
        }

        #region IDisposable
        /// <summary>
        /// 获取对象是否已释放
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// 关闭和释放所有相关资源
        /// </summary>
        public void Dispose()
        {
            if (this.IsDisposed == false)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            this.IsDisposed = true;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~HttpApiConfig()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">是否也释放托管资源</param>
        protected virtual void Dispose(bool disposing)
        {
            //if (this.httpClient != null)
            //{
            //    this.httpClient.Dispose();
            //}
        }
        #endregion
    }
}
