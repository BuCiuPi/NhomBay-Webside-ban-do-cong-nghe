using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using System;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        CoralCivetContext context = new CoralCivetContext();
        // GET: Admin/Auth
        public ActionResult loginAdmin(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (User.Identity.IsAuthenticated)
            {
                return Redirect(ReturnUrl ?? Url.Action("Index", "Home", new { area = "Admin" }));
            }
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LoginAdmin(string UserName, string Password, string ReturlUrl)
        //{
        //    String Username = fc["username"];
        //    string Pass = MyString.ToMD5(fc["password"]);
        //    ViewBag.error = Pass;
        //    return View();
        //}

        //public ActionResult logoutAdmin()
        //{
        //    Session["UserAdmin"] = "";
        //    Session["UserId"] = "";
        //    Response.Redirect("~/Admin/loginAdmin");
        //    return View();
        //}
    }
}