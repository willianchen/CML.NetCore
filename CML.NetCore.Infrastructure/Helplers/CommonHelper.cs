using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Helplers
{
	/// <summary>
	/// Copyright (C) 2017 cml 版权所有。
	/// 类名：CommonHelper.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：CommonHelper
	/// 创建标识：cml 2018/1/25 17:01:30
	/// </summary>
   public static class CommonHelper
    {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>()
        {
            var type = typeof(T);
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        /// <summary>
        /// 换行符
        /// </summary>
        public static string Line => Environment.NewLine;
    }
}
