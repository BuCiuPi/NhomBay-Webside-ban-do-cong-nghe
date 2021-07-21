using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        CoralCivetContext context = new CoralCivetContext();
        public ActionResult Index()
        {
            ViewBag.Types = context.Types.Where(p => p.parentId == null).ToList();
            ViewBag.Products = context.Products.ToList().Take(4);
            return View();
        }

        public ActionResult Detail(Product product)
        {
            
            ViewBag.ProductDetail = context.Products.FirstOrDefault(p => p.ID == product.ID);
            ViewBag.Products = context.Products.ToList().Take(4);
            return View();
        }
    }
}