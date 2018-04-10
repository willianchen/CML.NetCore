using CML.Lib.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Exceptions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ExceptionConvertUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ExceptionConvertUtil
    /// 创建标识：cml 2018/4/9 19:47:16
    /// </summary>
    public static class ExceptionConvertUtil
    {
        private static IExceptionErrorInfoConverter _convert;

        static ExceptionConvertUtil()
        {
            _convert = new ExceptionErrorInfoConverter();
        }

        public static ErrorInfo Convert(Exception exception)
        {
            return _convert.Convert(exception);
        }
    }
}
