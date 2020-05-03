using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web.Mvc;
using yourspace.Models;
using System.Data.Entity;

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
           
            // Elements for the view
            ViewBag.FirstName = userAccount.FirstName;
            ViewBag.LastName = userAccount.LastName;
            ViewBag.Bio = userAccount.Biography;
            ViewBag.postList = db.Posts.Where(p => p.AccountId == userAccount.AccountId);

            this.fillFriendsList();



            return View();
        }

        public void fillFriendsList()
        {
            // Query Syntax
            // ERROR: Caused a tracking Error with PK's of UserAccount (AccountID), where clause fixed this
            var allUsers = from user in db.UserAccount
                           where user.AccountId != UserAccount.AccountId
                           select user;


            foreach (var user in allUsers)
            {
                UserAccount.friendsList.Add(user.AccountId);
            }


            string jsonString = JsonConvert.SerializeObject(UserAccount.friendsList);
            UserAccount.FriendsList = jsonString;
            UserAccount.friendsList = JsonConvert.DeserializeObject<List<int>>(jsonString);


            db.Update(UserAccount); 
            db.SaveChanges();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserPost(SignUp signup)
        {
            UserAccount = ((UserAccount)Session["UserAccount"]);
            Posts post = new Posts();

            post.AccountId = ((UserAccount)Session["UserAccount"]).AccountId; // Proud if this cast works (It did!)
            post.PostTime = DateTime.Now;
            post.TextPost = signup.UserPost;

            // Maybe a better way to do this?
            ViewBag.FirstName = UserAccount.FirstName;
            ViewBag.LastName = UserAccount.LastName;
            ViewBag.Bio = UserAccount.Biography;
            ViewBag.postList = db.Posts.Where(p => p.AccountId == ((UserAccount)Session["UserAccount"]).AccountId);

            db.Posts.Add(post);
            db.SaveChanges();

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile()
        {
            return RedirectToAction("Index", "EditProfile", Session["UserAccount"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserHomePage()
        {
            return RedirectToAction("Index", "UserHomePage", Session["UserAccount"]);
        }
    }
}