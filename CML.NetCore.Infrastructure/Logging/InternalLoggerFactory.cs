using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.Contracts;
using System.Threading;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：InternalLoggerFactory.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：InternalLoggerFactory
    /// 创建标识：cml 2018/1/23 11:24:57
    /// </summary>
    public static class InternalLoggerFactory
    {
        static ILoggerFactory defaultFactory;


        static ILoggerFactory NewDefaultFactory(string name)
        {
            var f = new LoggerFactory();
            f.AddProvider(new NLoggerProvider());
            f.CreateLogger(name).LogDebug("Using NLoggerProvider as the default logging framework");
            return f;
        }
   
        /// <summary>
        ///     Gets or sets the default factory.
        /// </summary>
        public static ILoggerFactory DefaultFactory
        {
            get
            {
                ILoggerFactory factory = Volatile.Read(ref defaultFactory);
                if (factory == null)
                {
                    factory = NewDefaultFactory(typeof(InternalLoggerFactory).FullName);
                    ILoggerFactory current = Interlocked.CompareExchange(ref defaultFactory, factory, null);
                    if (current != null)
                    {
                        return current;
                    }
                }
                return factory;
            }
            set
            {
                Contract.Requires(value != null);

                Volatile.Write(ref defaultFactory, value);
            }
        }

        /// <summary>
        ///     Creates a new logger instance with the name of the specified type.
        /// </summary>
        /// <typeparam name="T">type where logger is used</typeparam>
        /// <returns>logger instance</returns>
        public static IInternalLogger GetInstance<T>() => GetInstance(typeof(T));

        /// <summary>
        ///     Creates a new logger instance with the name of the specified type.
        /// </summary>
        /// <param name="type">type where logger is used</param>
        /// <returns>logger instance</returns>
        public static IInternalLogger GetInstance(Type type) => GetInstance(type.FullName);

        /// <summary>
        ///     Creates a new logger instance with the specified name.
        /// </summary>
        /// <param name="name">logger name</param>
        /// <returns>logger instance</returns>
        public static IInternalLogger GetInstance(string name) => new GenericLogger(name, DefaultFactory.CreateLogger(name));
    }
}