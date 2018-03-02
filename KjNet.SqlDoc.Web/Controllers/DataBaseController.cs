using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KjNet.SqlDoc.Application;
using Microsoft.AspNetCore.Mvc;

namespace KjNet.SqlDoc.Web.Controllers
{
    public class DataBaseController : Controller
    {
        private readonly IDataBaseConfigApplication _dataBaseApplication;

        public DataBaseController(IDataBaseConfigApplication dataBaseApplication)
        {
            _dataBaseApplication = dataBaseApplication;
        }


        public IActionResult Index(int id = 2)
        {
            var result = _dataBaseApplication.GetDatabaseTableStructure(id);
            return View(result.Value);
        }
    }
}