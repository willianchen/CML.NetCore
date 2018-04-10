using CML.Lib.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Exceptions
{
	/// <summary>
	/// Copyright (C) 2017 cml 版权所有。
	/// 类名：IExceptionErrorInfoConverter.cs
	/// 类属性：接口
	/// 类功能描述：IExceptionErrorInfoConverter
	/// 创建标识：cml 2018/4/9 16:37:15
	/// </summary>
    public interface IExceptionErrorInfoConverter
    {
         ErrorInfo Convert(Exception exception);
    }
}
