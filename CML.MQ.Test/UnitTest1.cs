using CML.MQ.RabbitMQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace CML.MQ.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MQConfig config = new MQConfig("localhost", "guest", "guest") { VirtualHost = "/" };
            RabbitMQClient client = new RabbitMQClient(config);
            for (int i = 0; i < 100; i++)
            {
                MqModel message = new MqModel() { Message = "test message" + i.ToString(), SendDate = DateTime.Now };
                client.Publish(message);
                Thread.Sleep(1000);
            }
        }
    }

    [MQ(QueueName = "QueueName", ExchangeName = "ExchangeName", RoutingKey = "RoutingKey")]
    public class MqModel
    {
        public string Message { get; set; }
        public DateTime SendDate { get; set; }

    }
}
