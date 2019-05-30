using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Attributes
{
    /// <summary>
    /// TableName
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class TableNameAttribute : Attribute
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// otcr
        /// </summary>
        /// <param name="_tableName"></param>
        public TableNameAttribute(string _tableName)
        {
            TableName = _tableName;
        }
    }
}
