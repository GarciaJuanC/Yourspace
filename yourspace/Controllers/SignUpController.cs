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
    public class SignUpController : Controller {
        public ashenContext db = new ashenContext();
    
        public ActionResult Index()
        {
            return View();
        }

    }

}
