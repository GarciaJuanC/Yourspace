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
            ViewBag.FirstName = userAccount.FirstName;
            ViewBag.LastName = userAccount.LastName;
            ViewBag.Bio = userAccount.Biography;
            ViewBag.PhoneNum = userAccount.PhoneNumber;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EditProfile editProfile) 
        {
            //Account acc = new Account();


            thisUserAccount = db.UserAccount.Where(s => s.AccountId == ((UserAccount)Session["UserAccount"]).AccountId).FirstOrDefault();

            // Conditional statements so user doesnt't have to edit every attribute when they edit their profile

            if (editProfile.fName == null) { thisUserAccount.FirstName = thisUserAccount.FirstName; }
            else if (editProfile.fName != null) { thisUserAccount.FirstName = editProfile.fName; }

            if (editProfile.lName == null) { thisUserAccount.LastName = thisUserAccount.LastName; }
            else if (editProfile.lName != null) { thisUserAccount.LastName = editProfile.lName; }

            if (editProfile.phoneNum == null) { thisUserAccount.PhoneNumber = thisUserAccount.PhoneNumber; }
            else if (editProfile.phoneNum != null) { thisUserAccount.PhoneNumber = editProfile.phoneNum; }

            if (editProfile.biography == null) { thisUserAccount.Biography = thisUserAccount.Biography; }
            else if (editProfile.biography != null) { thisUserAccount.Biography = editProfile.biography; }
            
            db.UserAccount.Update(thisUserAccount);
            db.SaveChanges();

            return RedirectToAction("index", "Profile", thisUserAccount);
            
        }


    }
}