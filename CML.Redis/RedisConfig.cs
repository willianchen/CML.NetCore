using System;

namespace CML.Redis
{
    /// <summary>
    /// Redis配置类
    /// </summary>
    public class RedisConfig
    {
        /// <summary>
        /// 连接信息
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 数据库ID
        /// </summary>
        public int DatabaseId { get; set; }

        /// <summary>
        /// 分隔符
        /// </summary>
        public string NamespaceSplitSymbol { get; set; } = ":";

        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
    }
}
