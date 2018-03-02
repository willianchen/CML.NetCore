using System;
using System.Collections.Generic;
using System.Linq;
using CML.DataAccess;
using CML.DataAccess.DbClient;
using CML.DataAccess.Utils;
using CML.Lib.Configurations;
using CML.Lib.Result;
using KjNet.SqlDoc.Domain;
using KjNet.SqlDoc.Trans.Dto;

namespace KjNet.SqlDoc.Application.Implement
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DataBaseApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DataBaseApplication
    /// 创建标识：cml 2018/2/28 15:05:48
    /// </summary>
    public class DataBaseConfigApplication : IDataBaseConfigApplication
    {
        protected const string DatabaseKey = "DataBaseConfig";


        public OperateResult<List<DataBaseConfig>> GetDatabaseConfigs()
        {
            return OperateUtil.Execute(() =>
           {
               return ConfigurationHelper.GetAppSettings<List<DataBaseConfig>>(DatabaseKey);
           }, callMemberName: "AccessTokenApplication-CheckTokenAvailable");
        }

        /// <summary>
        /// 获取数据表，列结构
        /// </summary>
        /// <param name="dbId"></param>
        /// <returns></returns>
        public OperateResult<IEnumerable<TableStructureDto>> GetDatabaseTableStructure(int dbId)
        {
            return OperateUtil.Execute(() =>
            {

                var dbInfo = GetDatabaseConfigs().Value.Find(x => x.Id == dbId);

                if (dbInfo != null && !string.IsNullOrWhiteSpace(dbInfo.ConnectionString) && !string.IsNullOrWhiteSpace(dbInfo.DbType))
                {
                    var dbType = Enum.Parse<DatabaseType>(dbInfo.DbType);
                    var selectTableListSql = SqlQueryUtil.GetQueryTableListSql(dbType, dbInfo.DbName);
                    var selectTableColumnListSql = SqlQueryUtil.GetQueryTableColumnListSql(dbType, dbInfo.DbName);
                  //  var dataAccess =  DataAccessFactory.GetDataAccess(dbType, dbInfo.ConnectionString, false);
                    using (var dataAccess = DataAccessFactory.GetDataAccess(dbType, dbInfo.ConnectionString, false))
                    {
                        var tableSqlquery = new SqlQuery(selectTableListSql);
                        var tableList = dataAccess.Query<TableStructureDto>(tableSqlquery);
                        var tableColumnSqlQuery = new SqlQuery(selectTableColumnListSql);
                        var tableColumnList = dataAccess.Query<TableColumnStructureDto>(tableColumnSqlQuery);
                        foreach (var item in tableList)
                        {
                            item.ColumnList = tableColumnList.Where(m => m.TableName == item.TableName);
                        }
                        return tableList;
                    }
                }
                return null;
            }, callMemberName: "AccessTokenApplication-CheckTokenAvailable");

        }
    }
}
