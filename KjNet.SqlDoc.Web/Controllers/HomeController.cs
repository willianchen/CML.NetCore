using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KjNet.SqlDoc.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KjNet.SqlDoc.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataBaseConfigApplication _dataBaseApplication;

        public HomeController(IDataBaseConfigApplication dataBaseApplication)
        {
            _dataBaseApplication = dataBaseApplication;
        }

        // GET: Home
        public ActionResult Index()
        {
            var result = _dataBaseApplication.GetDatabaseConfigs();
            return View(result.Value);
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}