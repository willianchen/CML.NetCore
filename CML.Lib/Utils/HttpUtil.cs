using CML.Lib.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：HttpUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：http请求帮助类
    /// 创建标识：cq 2017/8/29 14:15:51
    /// </summary>
    public static class HttpUtil
    {
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string PostHttpRequest(string requestUri, string json)
        {
            //json格式请求数据
            string requestData = json;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            //utf-8编码
            byte[] buf = Encoding.GetEncoding("utf-8").GetBytes(requestData);

            //post请求
            myRequest.Method = "POST";
            myRequest.ContentLength = buf.Length;
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;

            //资金系统java接口需要添加
            myRequest.Headers.Add("Api-Version", "2.0");
            myRequest.ContentType = "application/json; charset=utf-8";
            myRequest.Accept = "application/json";

            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(buf, 0, buf.Length);
            newStream.Close();

            string ReqResult = string.Empty;
            HttpWebResponse myResponse = null;
            try
            {
                myResponse = (HttpWebResponse)myRequest.GetResponse();
                using (StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8))
                {
                    ReqResult = reader.ReadToEnd();
                }
  
            }
            catch (Exception e)
            {
                ReqResult = e.Message;
            }
            finally
            {
                myResponse?.Close();
                myResponse?.Dispose();
            }

            return ReqResult;
        }

        /// <summary>
        /// 异步Post请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<string> PostHttpRequestAsync(string requestUri, string json)
        {
            //json格式请求数据
            string requestData = json;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            //utf-8编码
            byte[] buf = Encoding.GetEncoding("utf-8").GetBytes(requestData);

            //post请求
            myRequest.Method = "POST";
            myRequest.ContentLength = buf.Length;
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;

            //资金系统java接口需要添加
            //myRequest.Headers.Add("Api-Version", "2.0");
            myRequest.ContentType = "application/json; charset=utf-8";
            myRequest.Accept = "application/json";

            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(buf, 0, buf.Length);
            newStream.Close();

            string ReqResult = string.Empty;
            HttpWebResponse myResponse = null;
            try
            {
                myResponse = (HttpWebResponse)await myRequest.GetResponseAsync();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                ReqResult = reader.ReadToEnd();
                reader.Close();
                myResponse.Close();
            }
            catch (Exception e)
            {
                ReqResult = e.Message;
            }

            return ReqResult;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public static string GetHttpRequest(string requestUri)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUri);
                myRequest.UseDefaultCredentials = true;
                myRequest.ContentType = "application/json; charset=utf-8";
                myRequest.Accept = "application/json";
                myRequest.Method = "GET";
                //资金系统java接口需要添加
                myRequest.Headers.Add("Api-Version", "2.0");
                string ReqResult = string.Empty;
                HttpWebResponse myResponse = null;
                myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                ReqResult = reader.ReadToEnd();
                reader.Close();
                myResponse.Close();

                return ReqResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 异步Get请求
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async static Task<string> GetHttpRequestAsync(string requestUri)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUri);
                myRequest.UseDefaultCredentials = true;
                myRequest.ContentType = "application/json; charset=utf-8";
                myRequest.Accept = "application/json";
                myRequest.Method = "GET";
                //资金系统java接口需要添加
                myRequest.Headers.Add("Api-Version", "2.0");
                string ReqResult = string.Empty;
                HttpWebResponse myResponse = null;
                myResponse = (HttpWebResponse)await myRequest.GetResponseAsync();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                ReqResult = reader.ReadToEnd();
                reader.Close();
                myResponse.Close();

                return ReqResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        ///获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTime()
        {
            var timeunit = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;//13位时间戳
            return timeunit;
        }

        /// <summary>
        /// 获取用于签名的字符串(参数首字母排序,然后参数和数值串在一起)
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetSignContent(IDictionary<string, string> parameters)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append("=").Append(value).Append("&");
                    query.Append(value);
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);
            return content;
        }

        /// <summary>
        /// 获取用于签名的字符串(参数首字母排序,然后数值串在一起)
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetSignContentOnlyValue(IDictionary<string, string> parameters)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数值串在一起
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(value))
                {
                    query.Append(value);
                }
            }
            string content = query.ToString();
            return content;
        }

        /// <summary>
        /// 签名（主要用于钱包内部接口的签名）
        /// </summary>
        /// <param name="dept_number">事业部编码</param>
        /// <param name="time">时间戳</param>
        /// <param name="signContent">用于前面的字符串</param>
        /// <param name="deptSecret">事业部密钥</param> 
        /// <returns></returns>
        public static string Sign(string dept_number, long time, string signContent, string deptSecret)
        {
            //MD5(事业部密钥+事业部编码+时间戳+拼接后的业务参数值)
            return (deptSecret + dept_number + time.ToString() + signContent).ToMd5();
        }
    }
}
