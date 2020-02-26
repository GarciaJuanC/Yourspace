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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLogin(string password, string email)
        {
            var _acc = db.Account.Where(s => s.Email == email);
            if (_acc.Any())
            {
                if (_acc.Where(s => s.HashedPass == getMD5(password + s.SaltValue)).Any())
                {

                    return RedirectToAction("Index","Home");
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