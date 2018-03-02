using CML.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Test
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：Demo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Demo
    /// 创建标识：cml 2018/2/27 16:18:24
    /// </summary>
    public class Demo
    {
        [Key]
        [Identity]
        public int FID { get; set; }
        public string FName { get; set; }

        public int FAge { get; set; }

        public DateTime FBirthday { get; set; }
    }
}
