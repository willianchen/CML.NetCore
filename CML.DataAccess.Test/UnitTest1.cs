using CML.DataAccess.Test.Common;
using CML.Lib.Configurations;
using CML.Lib.Json;
using CML.Lib.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CML.DataAccess.Test
{
    [TestClass]
    public class UnitTest1
    {
        static readonly IInternalLogger LogUtil = InternalLoggerFactory.GetInstance(typeof(UnitTest1));
        [TestMethod]
        public void TestMethod1()
        {

            BootStrap.Init();
        //    ConfigurationHelper.SetConsoleLogger();
            LogUtil.Error("asdf");
            DemoRepository demo = new DemoRepository(new DataAccessFactory());
            var list = demo.QueryList();
            var jsonList = new NewtonsoftJsonSerializer().GetJsonByObj(list);
            Console.WriteLine(jsonList);
        }
    }
}
