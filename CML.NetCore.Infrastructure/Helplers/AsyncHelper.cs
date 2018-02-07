using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CML.Lib.Logging;
using Nito.AsyncEx;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AsyncHelper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：异步执行操作类
    /// 创建标识：cml 2018/1/30 11:41:05
    /// </summary>
    public static class AsyncHelper
    {
        static readonly IInternalLogger Logger = InternalLoggerFactory.GetInstance(typeof(AsyncHelper));

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="action">操作,范例：Async.Run( async () => await SendAsync() );</param>
        public static void Run(Action action)
        {
            try
            {
                AsyncContext.Run(action);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="action">操作,范例：Async.Run( async () => await SendAsync() );</param>
        public static void Run(Func<Task> action)
        {
            try
            {
                AsyncContext.Run(action);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="action">操作,范例：Async.Run( async () => await SendAsync() );</param>
        public static TResult Run<TResult>(Func<TResult> action)
        {
            try
            {
                return AsyncContext.Run(action);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return default(TResult);
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="action">操作,范例：Async.Run( async () => await SendAsync() );</param>
        public static TResult Run<TResult>(Func<Task<TResult>> action)
        {
            try
            {
                return AsyncContext.Run(action);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return default(TResult);
        }
    }
}
