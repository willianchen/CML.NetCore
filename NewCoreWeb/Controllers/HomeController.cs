using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CML.Applications;
using Microsoft.AspNetCore.Mvc;
using NewCoreWeb.Models;

namespace NewCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserApplication _userApplication;

        public HomeController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public IActionResult Index()
        {
            var login = _userApplication.Login("123", "1234");
            ViewBag.LoginVal = login;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
