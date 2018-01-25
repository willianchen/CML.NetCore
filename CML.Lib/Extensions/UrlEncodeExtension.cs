using System.Text;
using System.Web;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：UrlEncodeExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：Url加解密帮助米
    /// 创建标识：yjq 2017/7/12 18:24:38
    /// </summary>
    public static class UrlEncodeExtension
    {
        #region 对字符串进行Url编码

        /// <summary>
        /// 对字符串进行Url编码
        /// </summary>
        /// <param name="str">要编码的字符串</param>
        /// <param name="encodeName">编码格式</param>
        /// <returns>Url编码后的字符</returns>
        public static string UrlEncode(this string str, string encodeName)
        {
            return HttpUtility.UrlEncode(str, Encoding.GetEncoding(encodeName));
        }

        /// <summary>
        /// 对字符串进行Url编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        #endregion 对字符串进行Url编码

        #region 对字符串进行Url解码

        /// <summary>
        /// 对字符串进行Url解码
        /// </summary>
        /// <param name="str">需要解码的字符串</param>
        /// <param name="decodeName">编码格式</param>
        /// <returns>Url解码后的字符串</returns>
        public static string UrlDecode(this string str, string decodeName)
        {
            return HttpUtility.UrlDecode(str, Encoding.GetEncoding(decodeName));
        }

        /// <summary>
        /// 对字符串进行Url解码
        /// </summary>
        /// <param name="str">需要解码的字符串</param>
        /// <returns>Url解码后的字符串</returns>
        public static string UrlDecode(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        #endregion 对字符串进行Url解码
    }
}