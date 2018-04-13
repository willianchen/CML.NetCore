using System;
using CML.Lib.Configurations;
using CML.Lib.Extensions;
using CML.Lib.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CML.Lib.Test
{
    [TestClass]
    public class UnitTest1
    {
        static readonly ILog Logger = LogFactory.GetInstance(typeof(UnitTest1));
        [TestMethod]

        public void TestMethod1()
        {
            ConfigurationHelper.SetConsoleLogger();
            Source s = new Source() { Name = "name", Age = 21, Birthday = DateTime.Now };
            Dest t = s.MapTo<Dest>();
        //    Logger.Debug(t.ToJson());
            Console.Write(t.ToJson());
        }
    }

    public class Source
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

    }

    public class Dest
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
