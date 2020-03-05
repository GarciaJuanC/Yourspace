using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using yourspace.Models;
using System.Text;

namespace yourspace.Controllers
{
    
    public class SignUpController : Controller
    {
        public ashenContext db = new ashenContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SignUp signup)
        {
            Account acc = new Account();
            UserAccount uAcc = new UserAccount();

            acc.Email = signup.Email;
            acc.HashedPass = signup.Password;
            acc.SaltValue = "1234";
            acc.AccountId = 1;
            uAcc.AccountId = acc.AccountId;
            uAcc.FirstName = signup.fName;
            uAcc.MiddleName = signup.mName;
            uAcc.LastName = signup.lName;
            uAcc.DateOfBirth = signup.dob;
            uAcc.PhoneNumber = signup.phoneNum;

            db.Account.Add(acc);
            db.UserAccount.Add(uAcc);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");




        }

    }

}
