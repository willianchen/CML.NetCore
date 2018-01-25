using Castle.DynamicProxy;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BaseMonitorIntercept.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/24 16:49:07
    /// </summary>
    public abstract class BaseMonitorIntercept : IInterceptor
    {
        /// <summary>
        /// 异步类型(无返回值)
        /// </summary>
        private static readonly Type _AsyncActionType = typeof(Task);

        /// <summary>
        /// 异步方法类型(有返回值)
        /// </summary>
        private static readonly Type _AsyncFunctionType = typeof(Task<>);

        /// <summary>
        /// 异步方法处理
        /// </summary>
        private static readonly MethodInfo handleAsyncMethodInfo = typeof(BaseMonitorIntercept).GetMethod("MonitorAsyncFunction", BindingFlags.Instance | BindingFlags.NonPublic);

        private readonly TimeElapsedStatistic _timeElapsedStatistic;

        public BaseMonitorIntercept(TimeElapsedStatistic timeElapsedStatistic)
        {
            _timeElapsedStatistic = timeElapsedStatistic;
        }

        public abstract TimeElapsedType TimeElapsedType { get; }

        public void Intercept(IInvocation invocation)
        {
            var delegateType = GetDelegateType(invocation);
            if (delegateType == MethodType.Synchronous)
            {
                Monitor(() => invocation.Proceed(), $"{invocation.TargetType.FullName}-{invocation.Method.Name}");
            }
            else if (delegateType == MethodType.AsyncAction)
            {
                invocation.Proceed();
                invocation.ReturnValue = MonitorAsync((Task)invocation.ReturnValue, $"{invocation.TargetType.FullName}-{invocation.Method.Name}");
            }
            else
            {
                invocation.Proceed();
                ExecuteHandleAsyncWithResultUsingReflection(invocation);
            }
        }

        /// <summary>
        /// 获取方法类型
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        private MethodType GetDelegateType(IInvocation invocation)
        {
            var returnType = invocation.Method.ReturnType;
            if (returnType == _AsyncActionType)
                return MethodType.AsyncAction;
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == _AsyncFunctionType)
                return MethodType.AsyncFunction;
            return MethodType.Synchronous;
        }

        /// <summary>
        /// 执行异步方法
        /// </summary>
        /// <param name="invocation"></param>
        private void ExecuteHandleAsyncWithResultUsingReflection(IInvocation invocation)
        {
            var resultType = invocation.Method.ReturnType.GetGenericArguments()[0];
            var mi = handleAsyncMethodInfo.MakeGenericMethod(resultType);
            invocation.ReturnValue = mi.Invoke(this, new[] { invocation.ReturnValue, TimeElapsedType, $"{invocation.TargetType.FullName}-{invocation.Method.Name}" });
        }

        /// <summary>
        /// 方法类型
        /// </summary>
        private enum MethodType
        {
            /// <summary>
            /// 同步方法
            /// </summary>
            Synchronous,

            /// <summary>
            /// 异步(无返回值)
            /// </summary>
            AsyncAction,

            /// <summary>
            /// 异步方法(有返回值)
            /// </summary>
            AsyncFunction
        }

        private void Monitor(Action executeAction, string memberName = null)
        {
            TimeElapsedInfo timeElapsedInfo = new TimeElapsedInfo();
            DateTime startTime = DateTime.Now;
            timeElapsedInfo.ExecuteTime = startTime;
            try
            {
                executeAction();
                timeElapsedInfo.IsSuccess = true;
            }
            catch (Exception ex)
            {
                timeElapsedInfo.IsSuccess = false;
                timeElapsedInfo.Remark = ex.Message;
                throw;
            }
            finally
            {
                timeElapsedInfo.TimeElapsed = (DateTime.Now - startTime).TotalMilliseconds;
                timeElapsedInfo.CallMemberName = memberName;
                timeElapsedInfo.TimeElapsedType = TimeElapsedType;
                _timeElapsedStatistic.AddTimeElapsedInfo(timeElapsedInfo);
            }
        }

        private async Task MonitorAsync(Task task, string memberName = null)
        {
            TimeElapsedInfo timeElapsedInfo = new TimeElapsedInfo();
            DateTime startTime = DateTime.Now;
            timeElapsedInfo.ExecuteTime = startTime;
            try
            {
                timeElapsedInfo.IsSuccess = true;
                await task;
            }
            catch (Exception ex)
            {
                timeElapsedInfo.IsSuccess = false;
                timeElapsedInfo.Remark = ex.Message;
                throw;
            }
            finally
            {
                timeElapsedInfo.TimeElapsed = (DateTime.Now - startTime).TotalMilliseconds;
                timeElapsedInfo.CallMemberName = memberName;
                timeElapsedInfo.TimeElapsedType = TimeElapsedType;
                _timeElapsedStatistic.AddTimeElapsedInfo(timeElapsedInfo);
            }
        }

        private async Task<T> MonitorAsyncFunction<T>(Task<T> task, TimeElapsedType elapsedType, string memberName = null)
        {
            TimeElapsedInfo timeElapsedInfo = new TimeElapsedInfo();
            DateTime startTime = DateTime.Now;
            timeElapsedInfo.ExecuteTime = startTime;
            try
            {
                timeElapsedInfo.IsSuccess = true;
                return await task;
            }
            catch (Exception ex)
            {
                timeElapsedInfo.IsSuccess = false;
                timeElapsedInfo.Remark = ex.Message;
                throw;
            }
            finally
            {
                timeElapsedInfo.TimeElapsed = (DateTime.Now - startTime).TotalMilliseconds;
                timeElapsedInfo.CallMemberName = memberName;
                timeElapsedInfo.TimeElapsedType = elapsedType;
                _timeElapsedStatistic.AddTimeElapsedInfo(timeElapsedInfo);
            }
        }
    }
}