using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
   

        // GET: Admin/Auth
        public ActionResult loginAdmin()
        {
            ViewBag.error = "";
            return View("loginAdmin");
        }

        [HttpPost]
        public ActionResult LoginAdmin(FormCollection fc)
        {
            String Username = fc["username"];
            string Pass =MyString.ToMD5( fc["password"]);
            ViewBag.error = Pass;
            return View();
        }

            public ActionResult logoutAdmin()
        {
            Session["UserAdmin"] = "";
            Session["UserId"] = "";
            Response.Redirect("~/Admin/loginAdmin");
            return View();
        }
    }
}