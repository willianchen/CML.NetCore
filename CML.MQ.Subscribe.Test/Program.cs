using CML.MQ.RabbitMQ;
using CML.Lib.Extensions;
using System;

namespace CML.MQ.Subscribe.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Console.WriteLine("开始订阅消息");
            MQConfig config = new MQConfig("localhost", "guest", "guest") { VirtualHost = "/" };
            RabbitMQClient client = new RabbitMQClient(config);
            client.Subscribe<MqModel>((x) =>
            {
                Console.WriteLine("订阅消息||" + x.ToJson());
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

