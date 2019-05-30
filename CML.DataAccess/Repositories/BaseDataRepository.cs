using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CML.DataAccess.Attributes;
using CML.DataAccess.DbClient;
using CML.DataAccess.Utils;
using CML.Lib.Domains;

namespace CML.DataAccess.Repositories
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：BaseDataRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BaseDataRepository
    /// 创建标识：cml 2018/2/27 13:31:02
    /// </summary>
    public class BaseDataRepository<T> : IBaseDataRepository<T> where T : class, new()
    {
        private readonly IDataAccessFactory _dataAccessFactory;
        private readonly string _configName;
        private readonly string _tableName;
        private readonly DatabaseType _readDateType;
        private readonly DatabaseType _writerDataType;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="dataAccessFactory"></param>
        /// <param name="configName"></param>
        public BaseDataRepository(IDataAccessFactory dataAccessFactory, string configName = "Main") : this(dataAccessFactory, "", configName)
        {

        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="dataAccessFactory"></param>
        /// <param name="tableName"></param>
        /// <param name="configName"></param>
        public BaseDataRepository(IDataAccessFactory dataAccessFactory, string tableName, string configName)
        {

            _dataAccessFactory = dataAccessFactory;
            _tableName = tableName;
            _configName = configName;
            var tbNameAttr = GetTableName();
            if (!string.IsNullOrWhiteSpace(tbNameAttr))
            {
                _tableName = tbNameAttr;
            }
            var dataProperty = DBSettings.GetDatabaseProperty(ConfigName);
            if (dataProperty != null)
            {
                _readDateType = dataProperty.Reader.DatabaseType;
                _writerDataType = dataProperty.Writer.DatabaseType;
            }
        }
        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        private string GetTableName()
        {
            Type type = typeof(T);
            string tableName = string.Empty;    //数据库名
            var sd = type.GetCustomAttributes(true);
            for (int i = 0; i < sd.Count(); i++)
            {
                if (sd.GetValue(i).GetType().Name == "TableName")
                {
                    TableNameAttribute tableNameTmp = sd[i] as TableNameAttribute;
                    if (tableNameTmp != null)
                    {
                        tableName = tableNameTmp.TableName;
                    }
                }
            }
            return tableName;
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        protected virtual DatabaseType DataType { get { return DatabaseType.MySql; } }
        protected virtual DatabaseType ReaderDataType
        {
            get
            {
                return _readDateType;
            }
        }

        protected virtual DatabaseType WriterDataType
        {
            get
            {
                return _writerDataType;
            }
        }


        /// <summary>
        /// 表名
        /// </summary>
        protected string TableName { get { return _tableName; } }

        /// <summary>
        /// 配置文件名字
        /// </summary>
        protected string ConfigName { get { return _configName; } }

        #region 获取数据操作

        /// <summary>
        /// 获取数据操作
        /// </summary>
        /// <param name="isWrite">是否需要执行写操作</param>
        /// <returns>数据操作</returns>
        protected IDataAccess GetDataAccess(bool isWrite = true)
        {
            return _dataAccessFactory.GetDataAccess(_configName, isWriter: isWrite);
        }

        #endregion 获取数据操作

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="infoList"></param>
        public void BulkInsert(List<T> infoList)
        {
            GetDataAccess().BulkInsert(infoList, TableName);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="dataTable"></param>
        public void BulkInsert(DataTable dataTable)
        {
            GetDataAccess().BulkInsert(dataTable, TableName);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="infoList"></param>
        /// <returns></returns>
        public Task BulkInsertAsync(List<T> infoList)
        {
            return GetDataAccess().BulkInsertAsync(infoList, TableName);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public Task BulkInsertAsync(DataTable dataTable)
        {
            return GetDataAccess().BulkInsertAsync(dataTable, TableName);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Delete(object condition)
        {
            SqlQuery query = SqlQueryUtil.BuilderDeleteSqlQuery(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQuery(query);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> condition)
        {
            SqlQuery query = SqlQueryUtil.BuilderDeleteSqlQuery(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQuery(query);
        }

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(object condition)
        {
            SqlQuery query = SqlQueryUtil.BuilderDeleteSqlQuery(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQueryAsync(query);
        }

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Expression<Func<T, bool>> condition)
        {
            SqlQuery query = SqlQueryUtil.BuilderDeleteSqlQuery(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQueryAsync(query);
        }

        /// <summary>
        /// 查询结果数
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public int GetCount(object condition, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQueryCountSqlQuery(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalar<int>(query);
        }

        /// <summary>
        /// 查询结果数
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<T, bool>> condition, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQueryCountSqlQuery(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalar<int>(query);
        }

        /// <summary>
        /// 查询结果数
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public Task<int> GetCountAsync(object condition, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQueryCountSqlQuery(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalarAsync<int>(query);
        }

        /// <summary>
        /// 查询结果数
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public Task<int> GetCountAsync(Expression<Func<T, bool>> condition, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQueryCountSqlQuery(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalarAsync<int>(query);
        }

        /// <summary>
        /// 获取DTO
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="condition"></param>
        /// <param name="ignoreFields"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public TDto GetDto<TDto>(object condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<TDto>(condition, TableName, string.Empty, topCount: null, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalar<TDto>(query);
        }

        /// <summary>
        /// 获取DTO
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="condition"></param>
        /// <param name="ignoreFields"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public TDto GetDto<TDto>(Expression<Func<T, bool>> condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQueryTopSqlQuery<T>(condition, TableName, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalar<TDto>(query);
        }

        /// <summary>
        /// 获取DTO
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="condition"></param>
        /// <param name="ignoreFields"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public Task<TDto> GetDtoAsync<TDto>(object condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<TDto>(condition, TableName, string.Empty, topCount: null, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalarAsync<TDto>(query);
        }

        /// <summary>
        /// 获取DTO
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="condition"></param>
        /// <param name="ignoreFields"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public Task<TDto> GetDtoAsync<TDto>(Expression<Func<T, bool>> condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQueryTopSqlQuery<T>(condition, TableName, topCount: 1, dbType: ReaderDataType);
            return GetDataAccess().ExecuteScalarAsync<TDto>(query);
        }

        /// <summary>
        /// 获取模型
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ignoreFields"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public T GetInfo(object condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(condition, TableName, string.Empty, topCount: null, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalar<T>(query);
        }

        /// <summary>
        /// 获取模型
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ignoreFields"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public T GetInfo(Expression<Func<T, bool>> condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQueryTopSqlQuery<T>(condition, TableName, topCount: 1, dbType: ReaderDataType);
            return GetDataAccess().ExecuteScalar<T>(query);
        }

        /// <summary>
        /// 获取模型
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ignoreFields"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public Task<T> GetInfoAsync(object condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(condition, TableName, string.Empty, topCount: 1, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalarAsync<T>(query);
        }
        /// <summary>
        /// 获取模型
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ignoreFields"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public Task<T> GetInfoAsync(Expression<Func<T, bool>> condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(condition, TableName, string.Empty, topCount: null, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalarAsync<T>(query);
        }

        public object Insert(T info, string keyName = null, string[] ignoreFields = null, bool isIdentity = true)
        {
            SqlQuery query = SqlQueryUtil.BuilderInsertSqlQuery<T>(info, TableName, keyName, ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQuery(query);
        }

        public Task<object> InsertAsync(T info, string keyName = null, string[] ignoreFields = null, bool isIdentity = true)
        {
            SqlQuery query = SqlQueryUtil.BuilderInsertSqlQuery<T>(info, TableName, keyName, ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteScalarAsync<object>(query);
        }

        public void InsertMany(List<T> infoList, string keyName = null, string[] ignoreFields = null, bool isIdentity = true)
        {
            SqlQuery query = SqlQueryUtil.BuilderInsertManySqlQuery(infoList, TableName, keyName, ignoreFields, dbType: WriterDataType);
            GetDataAccess().ExecuteNonQuery(query);
        }

        public Task InsertManyAsync(List<T> infoList, string keyName = null, string[] ignoreFields = null, bool isIdentity = true)
        {
            SqlQuery query = SqlQueryUtil.BuilderInsertManySqlQuery(infoList, TableName, keyName, ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQueryAsync(query);
        }

        public IEnumerable<T> QueryList(bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(null, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).Query<T>(query);
        }

        public IEnumerable<T> QueryList(object condition, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(condition, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).Query<T>(query);
        }

        public IEnumerable<T> QueryList(Expression<Func<T, bool>> condition, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(condition, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).Query<T>(query);
        }

        public IEnumerable<TDto> QueryList<TDto>(string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<TDto>(null, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).Query<TDto>(query);
        }

        public IEnumerable<TDto> QueryList<TDto>(object condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<TDto>(condition, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).Query<TDto>(query);
        }

        public IEnumerable<TDto> QueryList<TDto>(Expression<Func<T, bool>> condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<TDto>(condition, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).Query<TDto>(query);
        }

        public Task<IEnumerable<T>> QueryListAsync(Expression<Func<T, bool>> condition, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(condition, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).QueryAsync<T>(query);
        }

        public Task<IEnumerable<TDto>> QueryListAsync<TDto>(Expression<Func<T, bool>> condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<TDto>(condition, TableName, string.Empty, topCount: null, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess(isWrite).QueryAsync<TDto>(query);
        }

        public Task<IEnumerable<T>> QueryListAsync(bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(null, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).QueryAsync<T>(query);
        }

        public Task<IEnumerable<T>> QueryListAsync(object condition, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<T>(condition, TableName, string.Empty, topCount: null, dbType: WriterDataType);
            return GetDataAccess(isWrite).QueryAsync<T>(query);
        }

        public Task<IEnumerable<TDto>> QueryListAsync<TDto>(string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<TDto>(null, TableName, string.Empty, topCount: null, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess(isWrite).QueryAsync<TDto>(query);
        }

        public Task<IEnumerable<TDto>> QueryListAsync<TDto>(object condition, string[] ignoreFields = null, bool isWrite = false)
        {
            SqlQuery query = SqlQueryUtil.BuilderQuerySqlQuery<TDto>(condition, TableName, string.Empty, topCount: null, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess(isWrite).QueryAsync<TDto>(query);
        }

        public PagerList<TModel> QueryPageList<TModel>(string selectColumn, string selectTable, string where, string order, int pageIndex, int pageSize, object cmdParms = null)
        {
            int totalCount = QueryCount(selectTable, where, cmdParms: cmdParms);
            var dataList = PageQuery<TModel>(selectColumn, selectTable, where, order, pageIndex, pageSize, cmdParms: cmdParms);
            return new PagerList<TModel>(pageIndex, pageSize, totalCount, dataList);
        }

        public Task<PagerList<TModel>> QueryPageListAsync<TModel>(string selectColumn, string selectTable, string where, string order, int pageIndex, int pageSize, object cmdParms = null)
        {
            return Task.FromResult(QueryPageList<TModel>(selectColumn, selectTable, where, order, pageIndex, pageSize, cmdParms: cmdParms));
        }

        /// <summary>
        /// 分页查询(目前只支持MSSQLServer)
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="selectColumn">需要查询的指定字段(多个之间用逗号隔开)</param>
        /// <param name="selectTable">需要查询的表</param>
        /// <param name="where">查询条件</param>
        /// <param name="order">排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">一页显示条目</param>
        /// <param name="cmdParms">条件值</param>
        /// <returns>分页查询结果</returns>
        protected IEnumerable<TModel> PageQuery<TModel>(string selectColumn, string selectTable, string where, string order, int pageIndex, int pageSize, object cmdParms = null)
        {
            SqlQuery query = SqlQueryUtil.BuilderQueryPageSqlQuery(selectColumn, selectTable, where, order, pageIndex, pageSize, dbType: ReaderDataType, cmdParms: cmdParms);
            return GetDataAccess(isWrite: false).Query<TModel>(query);
        }

        /// <summary>
        /// 异步分页查询(目前只支持MSSQLServer)
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="selectColumn">需要查询的指定字段(多个之间用逗号隔开)</param>
        /// <param name="selectTable">需要查询的表</param>
        /// <param name="where">查询条件</param>
        /// <param name="order">排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">一页显示条目</param>
        /// <param name="cmdParms">条件值</param>
        /// <returns>分页查询结果</returns>
        protected Task<IEnumerable<TModel>> PageQueryAsync<TModel>(string selectColumn, string selectTable, string where, string order, int pageIndex, int pageSize, object cmdParms = null)
        {
            return Task.FromResult(PageQuery<TModel>(selectColumn, selectTable, where, order, pageIndex, pageSize, cmdParms: cmdParms));
        }

        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="selectTable">查询的表</param>
        /// <param name="where">查询条件</param>
        /// <param name="cmdParms">参数</param>
        /// <param name="isWrite">是否为写</param>
        /// <returns>数量</returns>
        protected int QueryCount(string selectTable, string where, object cmdParms = null, bool isWrite = false)
        {
            StringBuilder selectSQL = new StringBuilder();
            selectSQL.Append(string.Format("SELECT COUNT(0) FROM {0} ", selectTable));
            if (!string.IsNullOrWhiteSpace(where)) selectSQL.Append(string.Format(" WHERE {0}", where));
            SqlQuery query = new SqlQuery(selectSQL.ToString(), cmdParms);
            return GetDataAccess(isWrite: isWrite).ExecuteScalar<int>(query);
        }

        /// <summary>
        /// 异步查询数量
        /// </summary>
        /// <param name="selectTable">查询的表</param>
        /// <param name="where">查询条件</param>
        /// <param name="cmdParms">参数</param>
        /// <param name="isWrite">是否为写</param>
        /// <returns>数量</returns>
        protected Task<int> QueryCountAsync(string selectTable, string where, object cmdParms = null, bool isWrite = false)
        {
            return Task.FromResult(QueryCount(selectTable, where, cmdParms, isWrite: isWrite));
        }

        public int Update(object data, object condition, string[] ignoreFields = null)
        {
            SqlQuery query = SqlQueryUtil.BuilderUpdateSqlQuery(data, condition, TableName, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQuery(query);
        }

        public int Update(object data, Expression<Func<T, bool>> condition, string[] ignoreFields = null)
        {
            SqlQuery query = SqlQueryUtil.BuilderUpdateSqlQuery(data, condition, TableName, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQuery(query);
        }

        public Task<int> UpdateAsync(object data, object condition, string[] ignoreFields = null)
        {
            SqlQuery query = SqlQueryUtil.BuilderUpdateSqlQuery(data, condition, TableName, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQueryAsync(query);
        }

        public Task<int> UpdateAsync(object data, Expression<Func<T, bool>> condition, string[] ignoreFields = null)
        {
            SqlQuery query = SqlQueryUtil.BuilderUpdateSqlQuery(data, condition, TableName, ignoreFields: ignoreFields, dbType: WriterDataType);
            return GetDataAccess().ExecuteNonQueryAsync(query);
        }
    }
}
