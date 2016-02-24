using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewData["test"] = "tsteee";
            ViewBag.test = "sdfasdf";
            ViewBag.Count = new List<int> { 1, 4, 5, 6 };
            return View();
        }

    }
}
