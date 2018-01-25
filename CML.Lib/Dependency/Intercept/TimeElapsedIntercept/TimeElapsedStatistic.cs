using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CML.Lib.Extensions;

namespace CML.Lib.Dependency.Intercept
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TimeElapsedStatistic.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：消耗统计(注意请求单列)
    /// 创建标识：yjq 2017/7/22 14:55:06
    /// </summary>
    public class TimeElapsedStatistic
    {
        private ConcurrentQueue<TimeElapsedInfo> _timeConsumerQueue = new ConcurrentQueue<TimeElapsedInfo>();

        /// <summary>
        /// 时间消耗类型
        /// </summary>
        public IEnumerable<TimeElapsedInfo> TimeElapsedList
        {
            get
            {
                return _timeConsumerQueue.ToArray();
            }
        }

        /// <summary>
        /// 添加消耗时间信息
        /// </summary>
        /// <param name="timeElapsedInfo">消耗时间信息</param>
        public void AddTimeElapsedInfo(TimeElapsedInfo timeElapsedInfo)
        {
            if (timeElapsedInfo != null)
            {
                _timeConsumerQueue.Enqueue(timeElapsedInfo);
            }
        }

        /// <summary>
        /// 添加消耗信息
        /// </summary>
        /// <param name="executeAction">执行的方法</param>
        /// <param name="timeElapsedType">消耗类型</param>
        /// <param name="memberName">调用的方法名字</param>
        public void AddTimeElapsedInfo(Action executeAction, TimeElapsedType timeElapsedType, string memberName = null)
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
                timeElapsedInfo.TimeElapsedType = timeElapsedType;
                AddTimeElapsedInfo(timeElapsedInfo);
            }
        }
    }
}