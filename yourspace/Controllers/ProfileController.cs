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
            // Query String for debugging
            
            ViewBag.FirstName = userAccount.FirstName;
            ViewBag.LastName = userAccount.LastName;
            ViewBag.Bio = userAccount.Biography;
            ViewBag.postList = db.Posts.Where(p => p.AccountId == userAccount.AccountId);

            //fillFriendsList(UserAccount);

            this.fillFriendsList();



            return View();
        }

        public void fillFriendsList()
        {
            UserAccount userAccount = db.UserAccount.AsNoTracking().Where(uA => uA.AccountId == UserAccount.AccountId).FirstOrDefault();

            var allUsers = from user in db.UserAccount
                           select user;

            foreach (var user in allUsers)
            {
                userAccount.friendsList.Add(user.AccountId);
            }

            // Serialize object

            // This prevents the error I was getting about tracking PK's!
            // SOURCE: https://stackoverflow.com/questions/13510204/json-net-self-referencing-loop-detected

            string jsonString = JsonConvert.SerializeObject(userAccount.friendsList, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            userAccount.FriendsList = jsonString;

            //foreach()

            //int x = JsonConvert.DeserializeObject<int>(jsonString);
            userAccount.friendsList = JsonConvert.DeserializeObject<List<int>>(jsonString);


            db.Update(userAccount); // ALSO changed this to not be db.UserAccount.Update... maybe this fixed the problem???
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
        public ActionResult EditProfile(LoginAccount logAcc)
        {
            return RedirectToAction("Index", "EditProfile", Session["UserAccount"]);
        }
    }
}