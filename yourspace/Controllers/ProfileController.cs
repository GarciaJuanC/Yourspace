using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yourspace.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your profile page";
            return View();
        }
    }
}