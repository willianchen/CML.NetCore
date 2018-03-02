using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Expressions
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DataMember.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DataMember
    /// 创建标识：cml 2018/2/28 11:00:06
    /// </summary>
    public sealed class DataMember
    {
        public DataMember(string name, object value, DataMemberType memberType)
        {
            Name = name;
            Value = value;
            MemberType = memberType;
        }

        public string Name { get; set; }

        public object Value { get; set; }

        public DataMemberType MemberType { get; set; }
    }
}