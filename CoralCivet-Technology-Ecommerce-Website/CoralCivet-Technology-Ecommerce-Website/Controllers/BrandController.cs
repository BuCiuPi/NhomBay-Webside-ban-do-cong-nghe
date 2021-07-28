using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using CoralCivet_Technology_Ecommerce_Website.Models.CustomModels;
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
        public ActionResult Index(int? Id)
        {
            BrandIndex model = new BrandIndex();
            if (Id==null)
            {
                model.brands = context.Brands.ToList();
            }
            else
            {
                model.brands = context.Brands.Where(p=>p.Id == Id ).ToList();
            }
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult GetBrandList()
        {
            return PartialView("_HeaderBands", context.Brands.Where(p => p.name != "NO BRAND").ToList());
        }
    }
}