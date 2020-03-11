using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yourspace.Models;

namespace yourspace.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(UserAccount userAccount)
        {
            ViewBag.Message = userAccount;
            return View();

        }
    }
}