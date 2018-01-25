using CML.Lib.Extensions;
using CML.Lib.Utils;
using System;
using System.Collections.Generic;

namespace CML.Lib.Configurations
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：Configuration.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：项目配置
    /// 创建标识：yjq 2017/7/15 15:19:02
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// 项目信息当前实例
        /// </summary>
        public static Configuration Instant { get; }

        private Stack<Action> _unstallActionList = new Stack<Action>();
        private Stack<Action> _installActionList = new Stack<Action>();
        private string _appConfigPath;

        #region .ctor

        private Configuration()
        {
        }

        static Configuration()
        {
            Instant = new Configuration();
        }

        #endregion .ctor

        /// <summary>
        /// 解析IP的文件地址
        /// </summary>
        public string IpDataPath { get; set; }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public string AppConfigPath
        {
            get
            {
                if (_appConfigPath.IsNullOrEmptyWhiteSpace())
                {
                    _appConfigPath = GetDefaultAppConfigPath();
                }
                return _appConfigPath;
            }
            set
            {
                _appConfigPath = value;
            }
        }

        private string GetDefaultAppConfigPath()
        {
            return FileUtil.GetDomianPath() + "/App_Data/Config/AppSetting.config";
        }

        /// <summary>
        /// 添加程序停止时要执行的方法
        /// </summary>
        /// <param name="action">执行的方法</param>
        public Configuration AddUnInStallAction(Action action)
        {
            _unstallActionList.Push(action);
            return this;
        }
        /// <summary>
        /// 添加开始执行的方法
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Configuration AddInstallAction(Action action)
        {
            _installActionList.Push(action);
            return this;
        }

        /// <summary>
        /// 停止时执行
        /// </summary>
        public void Unstall()
        {
            while (_unstallActionList.Count > 0)
            {
                var action = _unstallActionList.Pop();
                action?.Invoke();
            }
        }

        /// <summary>
        /// 程序启动时执行的方法
        /// <param name="ipDataPath">解析IP的文件地址</param>
        /// <param name="appConfigPath">配置文件地址（默认当前项目/App_Data/Config/AppSetting.config）</param>
        /// </summary>
        public static void Install(string ipDataPath = null, string appConfigPath = null)
        {
            if (ipDataPath.IsNotNullAndNotEmptyWhiteSpace())
            {
                Instant.IpDataPath = ipDataPath;
            }
            if (appConfigPath.IsNotNullAndNotEmptyWhiteSpace())
            {
                Instant.AppConfigPath = appConfigPath;
            }
            ConfigWatcherUtil.Install();//启动配置文件的监听
            foreach (var item in Instant._installActionList)
            {
                item?.Invoke();
            }
            Instant.AddUnInStallAction(FileWatchUtil.UnInstall);
        }

        /// <summary>
        /// 程序停止时执行的方法
        /// </summary>
        public static void UnInstall()
        {
            Instant?.Unstall();
        }
    }
}