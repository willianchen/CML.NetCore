using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Attributes
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：KeyAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：KeyAttribute
    /// 创建标识：cml 2018/2/8 16:54:07
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class KeyAttribute : Attribute
    {
    }
}