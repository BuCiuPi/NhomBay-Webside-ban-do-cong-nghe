using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public ActionResult login()
        {
            return View();
        }


        public ActionResult logout()
        {
            return View();
        }
    }
}