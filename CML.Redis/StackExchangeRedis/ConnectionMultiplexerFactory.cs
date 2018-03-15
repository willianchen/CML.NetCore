using CML.Lib.Utils;
using StackExchange.Redis;
using System;
using CML.Lib.Extensions;

namespace CML.Redis.StackExchangeRedis
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ConnectionMultiplexerFactory.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ConnectionMultiplexerFactory
    /// 创建标识：cml 2018/3/14 10:08:10
    /// </summary>
    public sealed class ConnectionMultiplexerFactory
    {

        /// <summary>
        /// Gets the database .
        /// </summary>
        public static IDatabase GetDatabase(RedisConfig config)
        {
            return GetConnectionMultiplexer(config).GetDatabase(config.DatabaseId);
        }

        /// <summary>
        /// Gets the database connection.
        /// </summary>
        public static ConnectionMultiplexer GetConnectionMultiplexer(RedisConfig config)
        {
            return new Lazy<ConnectionMultiplexer>(CreateConnectionMultiplexer(config)).Value;
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private static ConnectionMultiplexer CreateConnectionMultiplexer(RedisConfig config)
        {
            var conn = ConnectionMultiplexer.Connect(config.ConnectionString);
            conn.ConnectionFailed += Conn_ConnectionFailed;
            conn.ConnectionRestored += Conn_ConnectionRestored;
            conn.ErrorMessage += Conn_ErrorMessage;

            return conn;
        }

        /// <summary>
        /// redis内部发生错误时回掉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Conn_ErrorMessage(object sender, RedisErrorEventArgs e)
        {
            LogUtil.Debug($"redis内部发生错误,{e.EndPoint}:{e.Message}", loggerName: "ConnectionMultiplexerFactory");
        }

        /// <summary>
        /// 重新连接失败时回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Conn_ConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            LogUtil.Error($"redis重新连接时发生错误,{e.EndPoint}{e.Exception.ToErrMsg()}", loggerName: "ConnectionMultiplexerFactory");
        }

        /// <summary>
        /// 连接失败时回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Conn_ConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            LogUtil.Error($"redis连接时发生错误,{e.EndPoint}{e.Exception.ToErrMsg()}", loggerName: "ConnectionMultiplexerFactory");
        }
    }
}
