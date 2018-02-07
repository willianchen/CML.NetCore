using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DatabaseProperty.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DatabaseProperty
    /// 创建标识：cml 2018/2/6 14:59:28
    /// </summary>
    public sealed class DatabaseProperty
    {
        private DatabaseConnection _reader;
        private DatabaseConnection _writer;

        /// <summary>
        /// 读链接信息
        /// </summary>
        public DatabaseConnection Reader
        {
            get { return _reader; }
        }

        /// <summary>
        /// 写链接信息
        /// </summary>
        public DatabaseConnection Writer
        {
            get { return _writer; }
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="reader">读链接信息</param>
        /// <param name="writer">写链接信息</param>
        public DatabaseProperty(DatabaseConnection reader, DatabaseConnection writer)
        {
            _reader = reader;
            _writer = writer;
        }
    }
}