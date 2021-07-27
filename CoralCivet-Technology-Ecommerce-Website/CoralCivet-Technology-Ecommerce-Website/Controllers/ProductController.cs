using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using CoralCivet_Technology_Ecommerce_Website.Models.CustomModels;
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
            ProductIndex model = new ProductIndex();
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
        
        public ActionResult Detail(Product product)
        {
            ProductDetail model = new ProductDetail();
            model.products = context.Products.FirstOrDefault(p => p.ID == product.ID);
            model.typeDetails = context.TypeDetails.Where(p => p.ProductId == product.ID).ToList();
            model.imgs = context.ProductImgs.Where(p => p.productId == product.ID).ToList();
            model.orderProducts = new List<Product>();
            int count = 4;
            foreach (var item in context.Products.ToList())
            {
                if (count != 0)
                {
                    model.orderProducts.Add(item);
                    count--;
                }
            }
            return View(model);
        }
    }
}