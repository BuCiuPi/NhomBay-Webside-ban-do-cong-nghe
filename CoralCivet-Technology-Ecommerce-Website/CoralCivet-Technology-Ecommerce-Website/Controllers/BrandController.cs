using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        CoralCivetContext context = new CoralCivetContext();
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetBrandList()
        {
            return PartialView("_HeaderBands", context.Brands.Where(p => p.name != "NO BRAND").ToList());
        }
    }
}