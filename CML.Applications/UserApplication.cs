using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Applications
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：UserApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：UserApplication
    /// 创建标识：cml 2018/1/24 10:51:58
    /// </summary>
    public class UserApplication : IUserApplication
    {
        public bool Login(string userName, string pwd)
        {
            return userName == pwd;
        }
    }
}
