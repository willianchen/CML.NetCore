using CML.Lib.Extensions;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Xml;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigWacherUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：配置文件监控类
    /// 创建标识：yjq 2017/8/16 14:25:33
    /// </summary>
    public static class ConfigWacherUtil
    {
        private static FileWatchUtil _configFileWacth = null;
        private static ConcurrentDictionary<string, string> _configCache = new ConcurrentDictionary<string, string>();//配置文件的缓存

        /// <summary>
        /// 启动监听
        /// </summary>
        public static void Install()
        {
            _configFileWacth = new FileWatchUtil(ConfigUtil.GetAppConfigPath(), InternalConfigure, isStart: true);
        }

        /// <summary>
        /// 获取配置文件的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            if (key.IsNullOrEmptyWhiteSpace()) return null;
            string value = null;
            if (_configCache.TryGetValue(key, out value))
            {
                return value;
            }
            return null;
        }

        private static void InternalConfigure(FileStream configStream)
        {
            if (configStream == null)
            {
                LogUtil.Error("【configStream】为空");
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(configStream);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex.ToErrMsg("InternalConfigure"));
                doc = null;
            }

            if (doc != null)
            {
                XmlNode xNode = doc.SelectSingleNode("//appSettings");
                if (xNode != null && xNode.HasChildNodes)
                {
                    string key = string.Empty;
                    string value = string.Empty;
                    for (int i = 0; i < xNode.ChildNodes.Count; i++)
                    {
                        XmlElement childrenElement = xNode.ChildNodes[i] as XmlElement;
                        if (childrenElement != null)
                        {
                            key = childrenElement.GetAttribute("key");
                            value = childrenElement.GetAttribute("value");
                            if (key.IsNotNullAndNotEmptyWhiteSpace())
                            {
                                _configCache[key] = value;
                            }
                        }
                    }
                }
            }
        }
    }
}