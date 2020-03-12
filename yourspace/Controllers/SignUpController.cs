using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using yourspace.Models;
using System.Text;
using System.IO;

namespace yourspace.Controllers
{
    
    public class SignUpController : Controller
    {
        public ashenContext db = new ashenContext();
        public string ourPath = "";
        UserAccount uAcc = new UserAccount();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SignUp signup)
        {
            Account acc = new Account();

            acc.Email = signup.Email;
            acc.HashedPass = generateHash(signup.Password);
           
            uAcc.FirstName = signup.fName;
            uAcc.MiddleName = signup.mName;
            uAcc.LastName = signup.lName;
            uAcc.DateOfBirth = signup.dob;
            uAcc.PhoneNumber = signup.phoneNum;

            db.Account.Add(acc);
            db.UserAccount.Add(uAcc);
            db.SaveChanges();
            if (db.Account.Find(uAcc.AccountId) != null)
            {
                uploadPicture();
            }

            return View();
        }

        public string generateHash(string password)
        {
            string hashPass = "";

            return hashPass;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public ActionResult uploadPicture()
        {
            return View();
        }

        public ActionResult checkPicture(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/UserImages"),
                                            RandomString(30),
                                            Path.GetFileName(file.FileName));
                ourPath = path;
                file.SaveAs(path);
                uAcc.PhotoPath = ourPath;

                db.UserAccount.Add(uAcc);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

    }

}
