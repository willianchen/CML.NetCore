using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：NullLoginChecker.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NullLoginChecker
    /// 创建标识：cml 2018/4/8 16:44:49
    /// </summary>
    public class NullLoginChecker : ILoginChecker
    {
        public Task<bool> IsLogin()
        {
            return Task.FromResult(true);
        }
    }
}
