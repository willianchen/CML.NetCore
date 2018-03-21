using CML.Redis.StackExchangeRedis;
using CML.Redis.Test.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CML.Lib.Extensions;

namespace CML.Redis.Test
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Demo demo = new Demo { Birthday = DateTime.Now, FID = 1, UserName = "Ñ¹Á¦É½´ó" };
            var client = new StackExchangeRedisProvider().CreateClient(redisConfig);
            client.StringSet("test", "test");
            var retStr = client.StringGet<string>("test");
            Console.WriteLine("result of string:" + retStr);
            client.KeyRemove("test");
            client.HashSet("hash", "demo", demo);
            var retHash = client.HashGet<Demo>("hash", "demo");
            Console.WriteLine(retHash.ToJson());
            client.HashDelete("hash", "demo");
            client.Clear();
        }
    }
}
