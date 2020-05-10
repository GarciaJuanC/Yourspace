using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using yourspace.Models;
using System.Text;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Web.UI.WebControls;

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
        public ActionResult Create(SignUp signup) // Ask why SignUp object was passed?
        {
            Account acc = new Account();
            try
            {
                acc.Email = signup.Email;
                acc.SaltValue = RandomString(5);
                acc.HashedPass = generateHash(signup.Password + acc.SaltValue);

                db.Account.Add(acc);
                db.SaveChanges();

                acc = db.Account.Where(s => s.Email == signup.Email).FirstOrDefault();

                uAcc.AccountId = acc.AccountId;
                uAcc.FirstName = signup.fName;
                uAcc.MiddleName = signup.mName;
                uAcc.LastName = signup.lName;
                uAcc.DateOfBirth = signup.dob;
                uAcc.PhoneNumber = signup.phoneNum;

                db.UserAccount.Add(uAcc);
                db.SaveChanges();

                return RedirectToAction("uploadPicture", "SignUp");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Email", "Email has already been registered!");
                return View("Index",signup);
            }
        }

        public string generateHash(string saltyPass)
        {
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(saltyPass));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                hash = sBuilder.ToString();
            }
            return hash;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //GET fileUpload
        [HttpGet]
        public ActionResult uploadPicture()
        {
            return View();
        }



        [HttpPost]
        public ActionResult checkPicture(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string path = Server.MapPath("~/Content/Images/userPhoto/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string photoFilePath = Path.Combine(path, Path.GetFileName(file.FileName));
                ourPath = photoFilePath;
                file.SaveAs(photoFilePath);
                uAcc.PhotoPath = ourPath;

                //db.UserAccount.Add(uAcc);
                db.UserAccount.Update(uAcc);
                db.SaveChanges();
                ViewBag.Message = "File uploaded successfully";
                
                
                
                
                        //string path = Path.Combine(Server.MapPath("~/UserImages"), RandomString(30), Path.GetFileName(file.FileName));
                        //file.SaveAs(path); 
                        //uAcc.PhotoPath = path;

                        //db.UserAccount.Update(uAcc);
                        //db.SaveChanges();
                    }
                    //ViewBag.FileStatus = "File uploaded successfully.";
                
            
            return RedirectToAction("Index", "Home");
        }

    }

}
