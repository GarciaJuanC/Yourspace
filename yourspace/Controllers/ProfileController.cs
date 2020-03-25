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
        public UserAccount UserAccount;
        
        
        public ActionResult Index(UserAccount userAccount)
        {
            Session["UserAccount"] = userAccount;
            UserAccount = (UserAccount) Session["UserAccount"];
            IList<Posts> postList = new List<Posts>();
            // Query String for debugging
            //userAccount = db.UserAccount.Where(s => s.FirstName == "J").FirstOrDefault();
            ViewBag.FirstName = userAccount.FirstName;
            ViewBag.LastName = userAccount.LastName;
            ViewBag.Bio = userAccount.Biography;
            ViewBag.postList = db.Posts.Where(p => p.AccountId == userAccount.AccountId);
            


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserPost(SignUp signup)
        {
            Posts post = new Posts();

            post.AccountId = ((UserAccount)Session["UserAccount"]).AccountId; // Proud if this works
            post.PostTime = DateTime.Now;
            post.TextPost = signup.UserPost;

            db.Posts.Add(post);
            db.SaveChanges();

            return View();
        }
    }
}