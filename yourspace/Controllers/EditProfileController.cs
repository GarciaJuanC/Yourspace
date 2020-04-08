using yourspace.Models;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yourspace.Controllers
{
    public class EditProfileController : Controller
    {
        public ashenContext db = new ashenContext();
        UserAccount thisUserAccount;

        public ActionResult Index(UserAccount userAccount)
        {
            Session["UserAccount"] = userAccount;
            thisUserAccount = (UserAccount)Session["UserAccount"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EditProfile editProfile) 
        {
            //Account acc = new Account();


            thisUserAccount = db.UserAccount.Where(s => s.AccountId == ((UserAccount)Session["UserAccount"]).AccountId).FirstOrDefault();

            thisUserAccount.FirstName = editProfile.fName;
            thisUserAccount.LastName = editProfile.lName;
            thisUserAccount.PhoneNumber = editProfile.phoneNum;
            thisUserAccount.Biography = editProfile.biography;

            db.UserAccount.Update(thisUserAccount);
            db.SaveChanges();

            return RedirectToAction("index", "Profile", thisUserAccount);
            
        }


    }
}