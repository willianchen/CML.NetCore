using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Attributes
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IdentityAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：自增
    /// 创建标识：yjq 2017/10/9 10:03:23
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class IdentityAttribute : Attribute
    {
    }
}