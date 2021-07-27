using CoralCivet_Technology_Ecommerce_Website.Models;
using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using CoralCivet_Technology_Ecommerce_Website.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Controllers
{
    public class HomeController : Controller
    {
        CoralCivetContext context = new CoralCivetContext();
        public ActionResult Index()
        {
            HomeIndex model = new HomeIndex();
            model.types = context.Types.Where(p => p.parentId == null).ToList();

            model.products = new List<Product>();
            int count = 4;
            foreach (var item in context.Products.ToList())
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UnderConstruction()
        {

            return View();
        }

        public ActionResult ReturnHeaderCategory()
        {
            return PartialView("_HeaderCategory",context.Types.Where(p => p.parentId == null).ToList());
        }
    }
}