using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreeWeb.DemoIoc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreeWeb
{
    public class HomeController : Controller
    {
        private readonly IDemo _demo;
        public HomeController(IDemo demo)
        {
            _demo = demo;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.RetValue = _demo.ReturnID(1111);
            return View();
        }
    }
}
