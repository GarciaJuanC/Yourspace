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
        
        public ActionResult Index(UserAccount userAccount)
        {
            IList<Posts> postList = new List<Posts>();
            // Query String for debugging
            //userAccount = db.UserAccount.Where(s => s.FirstName == "J").FirstOrDefault();
            ViewBag.FirstName = userAccount.FirstName;
            ViewBag.LastName = userAccount.LastName;
            ViewBag.postList = db.Posts.Where(p => p.AccountId == userAccount.AccountId);
            


            return View();
        }
    }
}