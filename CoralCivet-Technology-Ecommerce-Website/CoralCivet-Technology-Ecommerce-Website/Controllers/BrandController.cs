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
        public ActionResult Index(int Id)
        {
            ProductIndex model = new ProductIndex();
            model.products = new List<Product>();
            int count = 4;
            foreach (var item in context.Products.Where(p=>p.brandId == Id).ToList())
            {
                if (count != 0)
                {
                    model.products.Add(item);
                    count--;
                }
            }

            model.sliders = context.sliders.Where(p => p.status == 1).ToList();
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult GetBrandList()
        {
            return PartialView("_HeaderBands", context.Brands.Where(p => p.name != "NO BRAND").ToList());
        }
    }
}