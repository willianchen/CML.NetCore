using CML.Lib.Result;
using KjNet.SqlDoc.Domain;
using KjNet.SqlDoc.Trans.Dto;
using System;
using System.Collections;
using System.Collections.Generic;

namespace KjNet.SqlDoc.Application
{
    public interface IDataBaseConfigApplication
    {
        OperateResult<List<DataBaseConfig>> GetDatabaseConfigs();

        OperateResult<IEnumerable<TableStructureDto>> GetDatabaseTableStructure(int dbId);
    }
}
