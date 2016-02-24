using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using ViewWeb.Filters;
using ViewWeb.Models;

namespace ViewWeb.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Main/
        public ActionResult Login()
        {
            return View();
        }

    }
}
