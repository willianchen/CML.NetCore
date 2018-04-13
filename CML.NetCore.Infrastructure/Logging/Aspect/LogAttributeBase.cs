using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using CML.Lib.Aspects.Base;
using CML.Lib.Logging.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Logging.Aspect
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：LoggerAttributeBase.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：日志拦截器
    /// 创建标识：cml 2018/4/13 14:01:36
    /// </summary>
    public abstract class LogAttributeBase : InterceptorBase
    {
        /// <summary>
        /// 执行
        /// </summary>
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var methodName = GetMethodName(context);
            var log = LogFactory.GetInstance(methodName);
            if (!Enabled(log))
                return;
            ExecuteBefore(log, context, methodName);
            await next(context);
            ExecuteAfter(log, context, methodName);
        }

        /// <summary>
        /// 获取方法名
        /// </summary>
        private string GetMethodName(AspectContext context)
        {
            return $"{context.ServiceMethod.DeclaringType.FullName}.{context.ServiceMethod.Name}";
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        protected virtual bool Enabled(ILog log)
        {
            return true;
        }

        /// <summary>
        /// 执行前
        /// </summary>
        private void ExecuteBefore(ILog log, AspectContext context, string methodName)
        {
            StringBuilder content = new StringBuilder();
            content.AppendFormat($"{methodName}方法执行前");
            foreach (var parameter in context.GetParameters())
                parameter.AppendTo(content);
            WriteLog(log, content.ToString());
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected abstract void WriteLog(ILog log, string content);

        /// <summary>
        /// 执行后
        /// </summary>
        private void ExecuteAfter(ILog log, AspectContext context, string methodName)
        {
            var parameter = context.GetReturnParameter();
            StringBuilder content = new StringBuilder();
            content.AppendFormat($"{methodName}方法执行后返回：");
            parameter.AppendTo(content);
            WriteLog(log, content.ToString());
        }
    }
}

