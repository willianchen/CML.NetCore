using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebTest.Models;
using NetCoreWebTest.DemoIoc;

namespace NetCoreWebTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDemo _demo;
        public HomeController(IDemo demo)
        {
            _demo = demo;
        }

        public IActionResult Index()
        {
            ViewBag.RetValue = _demo.ReturnID(1111);
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
