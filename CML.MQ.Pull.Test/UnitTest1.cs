using CML.MQ.RabbitMQ;
using CML.Lib.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CML.MQ.Pull.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MQConfig config = new MQConfig("localhost", "guest", "guest") { VirtualHost = "/" };
            RabbitMQClient client = new RabbitMQClient(config);
            client.Pull<MqModel>((x) =>
            {
                Console.WriteLine(x.ToJson());
            });
        }
    }

    [MQ(QueueName = "QueueName", ExchangeName = "ExchangeName", RoutingKey = "RoutingKey")]
    public class MqModel
    {
        public string Message { get; set; }
        public DateTime SendDate { get; set; }

    }
}
