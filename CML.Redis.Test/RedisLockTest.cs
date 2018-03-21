using CML.Redis.Lock;
using CML.Redis.StackExchangeRedis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CML.Redis.Test
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：RedisLockTest.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RedisLockTest
    /// 创建标识：cml 2018/3/21 15:19:53
    /// </summary>

    [TestClass]
    public class RedisLockTest : BaseTest
    {
        private int sum = 0;

        [TestMethod]
        public void TestLockAsync()
        {

            RedisLock redisLock = new RedisLock("redisCache", new StackExchangeRedisProvider(), redisConfig);
            for (var i = 0; i < 5000; i++)
            {
                Task.Factory.StartNew(() =>
            {

                var ret1 = Add();
                Console.WriteLine("task1: " + ret1);

            });
            }
            //Task.Factory.StartNew(() =>
            //{
            //    for (var i = 0; i < 10000; i++)
            //    {
            //        var ret2 = Add();
            //        Console.WriteLine("task2: " + ret2);

            //    }
            //});

            //redisLock.ExecuteWithLock("lock", "lock", TimeSpan.FromSeconds(100), () =>
            //{
            //    var ret = Add();
            //    Console.WriteLine("return " + ret);
            //});

            Console.WriteLine("sum:----" + sum);
        }

        public int Add()
        {
            sum++;
            Console.WriteLine("sum:" + sum);
            return sum;

        }
    }
}
