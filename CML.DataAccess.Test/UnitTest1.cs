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
            DemoRepository demoRep = new DemoRepository(new DataAccessFactory());
            
            #region ÐÂÔö
            Demo newDemo = new Demo() { FAge = 1, FBirthday = DateTime.Now, FName = "test1" };
            demoRep.Insert(newDemo);
            #endregion

            #region ²éÑ¯
            var list = demoRep.QueryList(x=>x.FName=="test1");
            var jsonList = new NewtonsoftJsonSerializer().GetJsonByObj(list);
            Console.WriteLine(jsonList);
            #endregion

        }
    }
}
