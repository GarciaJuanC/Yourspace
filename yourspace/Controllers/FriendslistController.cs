using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yourspace.Models;

namespace yourspace.Controllers
{
    public class FriendsListController : Controller
    {
        public ashenContext db = new ashenContext();
        UserAccount thisUserAccount;

        public ActionResult Index(UserAccount userAccount)
        {


            var allUsers = from user in db.UserAccount
                           select user;

            foreach (var user in allUsers)
            {
                userAccount.friendsList.Add(user);
            }

            // Serialize object
            string jsonString = JsonConvert.SerializeObject(userAccount.friendsList);

            userAccount.FriendsList = jsonString;


            // Possible solution: https://www.pmichaels.net/tag/dbcontextoptionsbuilder-enablesensitivedatalogging/
            db.UserAccount.Update(userAccount);
            db.SaveChanges();

            return RedirectToAction("Index", "Profile", userAccount);
        }
    }
}