using CML.Lib.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Result
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AjaxResponse.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AjaxResponse
    /// 创建标识：cml 2018/4/9 15:40:29
    /// </summary>
    public class AjaxResponse : AjaxResponse<object>
    {
        public AjaxResponse()
        {

        }

        public AjaxResponse(AjaxResponseState code)
            : base(code)
        {

        }

        public AjaxResponse(object result)
            : base(result)
        {

        }

        public AjaxResponse(ErrorInfo error)
            : base(error)
        {

        }
    }
}