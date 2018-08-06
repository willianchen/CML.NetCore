using CML.Lib.RestApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Test
{
    [TestClass]
    public class RestSharpTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string host = "http://dongqiudi.com";
            RestSharpClient client = new RestSharpClient(host);
            var response = client.Execute("archives/1", RestSharp.Method.GET, request => request.AddQueryParameter("page", "2"));
            Console.WriteLine(response.Content);
        }
    }
}
