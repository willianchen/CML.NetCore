using System;

namespace CML.MQ
{
    /// <summary>
    /// 消息队列交换机类型
    /// </summary>
    public static class MQExchangeType
    {
        /// <summary>
        /// Exchange type used for AMQP direct exchanges.
        /// </summary>
        public const string DIRECT = "direct";

        /// <summary>
        /// Exchange type used for AMQP fanout exchanges.
        /// </summary>
        public const string FANOUT = "fanout";

        /// <summary>
        /// Exchange type used for AMQP headers exchanges.
        /// </summary>
        public const string HEASERS = "headers";

        /// <summary>
        /// Exchange type used for AMQP topic exchanges.
        /// </summary>
        public const string TOPICS = "topic";
    }
}
