using CML.Lib.Logging;
using CML.Lib.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CML.AspNetCore.Filters
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RequestTraceAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RequestTraceAttribute
    /// 创建标识：cml 2018/4/16 14:43:00
    /// </summary>
    public class RequestTraceAttribute : ActionFilterAttribute
    {
        private const string Key = "action";
        private bool _IsDebugLog = true;

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (_IsDebugLog)
            {
                var actionName = GetControllerAndActionName(actionContext);
                ILog log = LogFactory.GetInstance(actionName);

                //Stopwatch stopWatch = new Stopwatch();


                //   actionContext.HttpContext.Request.Headers[Key] = stopWatch;

                //string actionName = actionContext.ActionDescriptor.DisplayName;


                log.Debug(actionContext.ActionArguments.ToJson());

                //  stopWatch.Start();
            }

        }
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (_IsDebugLog)
            {


                string actionName = GetControllerAndActionName(actionExecutedContext);
                ILog log = LogFactory.GetInstance(actionName);
                //    string controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                log.Debug(StreamToString(actionExecutedContext.HttpContext.Response.Body));
                //  Debug.Print(actionExecutedContext.Response.Content.ReadAsStringAsync().Result);

                //Debug.Print(string.Format(@"[{0}/{1} 用时 {2}ms]", controllerName, actionName, stopWatch.Elapsed.TotalMilliseconds));
            }
        }


        public string StreamToString(Stream stream)
        {
            Stream des = null;
            stream.CopyTo(des);
            StreamReader reader = new StreamReader(des);
            string text = reader.ReadToEnd();
            return text;
        }

        public string GetControllerAndActionName(ActionContext context)
        {
            return context + context.ActionDescriptor.DisplayName;
        }
    }
}
