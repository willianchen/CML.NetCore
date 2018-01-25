using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：SelfDisposable.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：SelfDisposable
    /// 创建标识：cml 2018/1/11 13:42:19
    /// </summary>
    public class SelfDisposable : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeCode()
        {
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCode();
            }
            _isDisposed = true;
        }

        ~SelfDisposable()
        {
            Dispose(false);
        }
    }
}