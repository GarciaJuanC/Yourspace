using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yourspace.Models;

namespace yourspace.Controllers
{
    public class ProfileController : Controller
    {
        public ashenContext db = new ashenContext();
        //private UserAccount userAccount;
        public ActionResult Index(UserAccount userAccount)
        {
            userAccount = db.UserAccount.Where(s => s.FirstName == "J").FirstOrDefault();
            Console.WriteLine(userAccount.FirstName);
            ViewBag.FirstName = userAccount.FirstName;
            ViewBag.Test = "Test STRANG";
            return View();
        }
    }
}