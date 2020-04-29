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

        public ActionResult Index(UserAccount userAccount)
        {
            Session["UserAccount"] = userAccount;
            thisUserAccount = (UserAccount)Session["UserAccount"];
            IList<Posts> friendsPostList = new List<Posts>();

            // Elements for the view
            ViewBag.FirstName = userAccount.FirstName;
            ViewBag.LastName = userAccount.LastName;
            thisUserAccount.friendsList = JsonConvert.DeserializeObject<List<int>>(thisUserAccount.FriendsList);


            foreach (int friendID in thisUserAccount.friendsList)
            {

                /*var allUsers = from user in db.UserAccount
                               where user.AccountId != UserAccount.AccountId
                               select user;*/

                var friendPosts = from post in db.Posts
                                 where post.AccountId == friendID
                                 select post;

                foreach(var post in friendPosts)
                {
                    friendsPostList.Add(post);
                }


                ViewBag.friendsPostList = friendsPostList;
            }

            

            return View();

            /* Session["UserAccount"] = userAccount;
             thisUserAccount = (UserAccount)Session["UserAccount"];
             ViewBag.FirstName = userAccount.FirstName;
             ViewBag.LastName = userAccount.LastName;
             ViewBag.Bio = userAccount.Biography;
             ViewBag.PhoneNum = userAccount.PhoneNumber;*/


        }
    }
}