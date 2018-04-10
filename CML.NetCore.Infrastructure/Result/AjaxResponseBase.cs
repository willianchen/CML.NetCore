using CML.Lib.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Result
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AjaxResponseBase.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AjaxResponseBase
    /// 创建标识：cml 2018/4/9 14:46:22
    /// </summary>
    public abstract class AjaxResponseBase
    {
        /// <summary>
        /// 目标跳转地址
        /// </summary>
        public string TargetUrl { get; set; }

        /// <summary>
        /// 响应码
        /// </summary>
        public AjaxResponseState Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public ErrorInfo Error { get; set; }

    }



    [Serializable]
    public class AjaxResponse<TResult> : AjaxResponseBase
    {

        public TResult Result { get; set; }

        public AjaxResponse(TResult result)
        {
            Result = result;
            Code = AjaxResponseState.Success;
        }

        public AjaxResponse()
        {
            Code = AjaxResponseState.Success;
        }

        public AjaxResponse(AjaxResponseState code)
        {
            Code = code;
        }

        public AjaxResponse(ErrorInfo error)
        {
            Error = error;
            Code = AjaxResponseState.Failed;
        }
    }
}
