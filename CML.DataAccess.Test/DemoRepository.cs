using CML.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.DataAccess.Test
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DemoRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DemoRepository
    /// 创建标识：cml 2018/2/27 16:14:30
    /// </summary>
    public class DemoRepository : BaseDataRepository<Demo>
    {
        protected const string configName = "Demo";
        protected const string tableName = "Demo";
        public DemoRepository(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory, tableName, configName)
        {

        }
    }
}
