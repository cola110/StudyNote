using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewWeb.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/
        // [HttpPost]
        public ActionResult Index()
        {
            ViewBag.UserName = "test";
            ViewBag.RoleName = "manager";
            return View();
        }

        //
        // GET: /Main/

        public ActionResult Test()
        {
            return View();
        }

    }
}
