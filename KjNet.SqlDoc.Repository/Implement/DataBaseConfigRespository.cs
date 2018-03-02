using CML.DataAccess;
using CML.DataAccess.Repositories;
using KjNet.SqlDoc.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KjNet.SqlDoc.Repository.Implement
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DataBaseConfigRespository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DataBaseConfigRespository
    /// 创建标识：cml 2018/3/1 10:53:25
    /// </summary>
    public class DataBaseConfigRespository : BaseDataRepository<DataBaseConfig>, IDataBaseConfigRespository
    {
        public DataBaseConfigRespository(IDataAccessFactory dataAccessFactory, string tableName, string configName) : base(dataAccessFactory, tableName, configName)
        {

        }
    }
}
