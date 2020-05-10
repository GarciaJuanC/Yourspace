using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yourspace.Models;

namespace yourspace.Controllers
{
    public class UserHomePageController : Controller
    {
        
        public ashenContext db = new ashenContext();
        UserAccount thisUserAccount;
        UserAccount friendAccount;
        int friendCount = 0;
        

        public ActionResult Index(UserAccount userAccount)
        {
            Session["UserAccount"] = userAccount;
            thisUserAccount = (UserAccount)Session["UserAccount"];
            IList<Posts> friendsPostList = new List<Posts>();

            // Elements for the view
            ViewBag.FirstName = userAccount.FirstName;
            ViewBag.LastName = userAccount.LastName;

            if(thisUserAccount.FriendsList != null)
            {
                thisUserAccount.friendsList = JsonConvert.DeserializeObject<List<int>>(thisUserAccount.FriendsList);
                thisUserAccount.hasFriends = true;
            }
            


            // Populate friendsListPosts
            foreach (int friendID in thisUserAccount.friendsList)
            {
                friendCount++;
                var friendPosts = from post in db.Posts
                                 where post.AccountId == friendID
                                 select post;

                foreach(var post in friendPosts)
                {
                    friendsPostList.Add(post);
                }


                ViewBag.friendsPostList = friendsPostList;
                
            }
            ViewBag.friendCount = friendCount;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfilePage()
        {
            return RedirectToAction("Index", "Profile", Session["UserAccount"]);
        }


    }
}