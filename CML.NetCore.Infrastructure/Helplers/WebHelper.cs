using Microsoft.AspNetCore.Http;
using CML.Lib.Dependency;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using CML.Lib.Extensions;
using Microsoft.AspNetCore.Http.Extensions;

namespace CML.Lib.Helplers
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：WebHelper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：WebHelper
    /// 创建标识：cml 2018/1/25 11:42:42
    /// </summary>
    public static class WebHelper
    {

        #region 静态构造方法

        /// <summary>
        /// 初始化Web操作
        /// </summary>
        static WebHelper()
        {
            try
            {
                HttpContextAccessor = ContainerManager.Resolve<IHttpContextAccessor>();
            }
            catch
            {
            }
        }

        #endregion

        #region 属性

        /// <summary>
        /// Http上下文访问器
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor { get; set; }

        /// <summary>
        /// 当前Http上下文
        /// </summary>
        public static HttpContext HttpContext => HttpContextAccessor?.HttpContext;

        #endregion



        #region Url(请求地址)

        /// <summary>
        /// 请求地址
        /// </summary>
        public static string Url => HttpContext?.Request?.GetDisplayUrl();

        #endregion

        #region Ip(客户端Ip地址)

        /// <summary>
        /// 客户端Ip地址
        /// </summary>
        public static string Ip
        {
            get
            {
                var list = new[] { "127.0.0.1", "::1" };
                var result = HttpContext?.Connection?.RemoteIpAddress.ToSafeString();
                if (string.IsNullOrWhiteSpace(result) || list.Contains(result))
                    result = GetLanIp();
                return result;
            }
        }

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        private static string GetLanIp()
        {
            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        #endregion

        #region Host(主机)

        /// <summary>
        /// 主机
        /// </summary>
        public static string Host => HttpContext == null ? Dns.GetHostName() : GetClientHostName();

        /// <summary>
        /// 获取Web客户端主机名
        /// </summary>
        private static string GetClientHostName()
        {
            var address = GetRemoteAddress();
            if (string.IsNullOrWhiteSpace(address))
                return Dns.GetHostName();
            var result = Dns.GetHostEntry(IPAddress.Parse(address)).HostName;
            if (result == "localhost.localdomain")
                result = Dns.GetHostName();
            return result;
        }

        /// <summary>
        /// 获取远程地址
        /// </summary>
        private static string GetRemoteAddress()
        {
            return HttpContext?.Request?.Headers["HTTP_X_FORWARDED_FOR"] ?? HttpContext?.Request?.Headers["REMOTE_ADDR"];
        }

        #endregion

        #region Browser(浏览器)

        /// <summary>
        /// 浏览器
        /// </summary>
        public static string Browser => HttpContext?.Request?.Headers["User-Agent"];

        #endregion
    }
}
