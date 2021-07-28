using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        // GET: Admin/AdminDashboard
        public ActionResult Index()
        {
            if (Session["UserAdmin"].Equals(""))
            {
                return Redirect("~/Admin/loginAdmin");
            }
            return View();
        }
    }
}