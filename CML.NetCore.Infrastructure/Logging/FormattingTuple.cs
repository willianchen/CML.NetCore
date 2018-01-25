using System;
using System.Diagnostics.Contracts;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：FormattingTuple.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：FormattingTuple
    /// 创建标识：cml 2018/1/22 16:27:23
    /// </summary>
    public class FormattingTuple
    {
        static readonly FormattingTuple NULL = new FormattingTuple(null);

        public FormattingTuple(string message)
            : this(message, null, null)
        {
        }

        public FormattingTuple(string message, object[] argArray, Exception exception)
        {
            this.Message = message;
            this.Exception = exception;
            if (exception == null)
            {
                this.ArgArray = argArray;
            }
            else
            {
                this.ArgArray = GetTrimmedCopy(argArray);
            }
        }

        public static object[] GetTrimmedCopy(object[] argArray)
        {
            Contract.Requires(argArray != null && argArray.Length > 0);

            int trimemdLen = argArray.Length - 1;
            var trimmed = new object[trimemdLen];
            Array.Copy(argArray, 0, trimmed, 0, trimemdLen);
            return trimmed;
        }

        public string Message { get; private set; }

        public object[] ArgArray { get; private set; }

        public Exception Exception { get; private set; }
    }
}