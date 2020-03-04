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
<<<<<<< HEAD
            return View();
=======
            UserAccount uAcc = new UserAccount();

            acc.Email = signup.Email;
            acc.HashedPass = signup.Password;
            uAcc.FirstName = signup.lName;
            uAcc.MiddleName = signup.mName;
            uAcc.LastName = signup.lName;
            uAcc.DateOfBirth = signup.dob;
            uAcc.PhoneNumber = signup.phoneNum;



>>>>>>> 32cb638bf166748dfc50f9e4c9b7a18dbed72558
        }

    }

}
