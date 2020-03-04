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
    public class LoginController : Controller
    {
        public ashenContext db = new ashenContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckLogin()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLogin(LoginAccount logAcc)
        {
            var _acc = db.Account.Where(s => s.Email == logAcc.Email).FirstOrDefault();
            if (_acc != null)
            {
                if (_acc.HashedPass == getMD5(logAcc.Password + _acc.SaltValue))
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        string getMD5(string saltyPass)
        {
            string hash;
            using(MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(saltyPass));

                StringBuilder sBuilder = new StringBuilder();

                for(int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                hash = sBuilder.ToString();
            }
            return hash;
        }
    }


}