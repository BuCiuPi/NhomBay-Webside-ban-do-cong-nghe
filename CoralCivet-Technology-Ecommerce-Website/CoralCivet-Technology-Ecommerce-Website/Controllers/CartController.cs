using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using CoralCivet_Technology_Ecommerce_Website.Models.CustomModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        CoralCivetContext context = new CoralCivetContext();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            CartIndex model = new CartIndex();
            var userId = User.Identity.GetUserId();
            model.Carts = context.Carts.Where(p=> p.userId == userId).ToList();
            foreach (var item in model.Carts)
            {
                model.total += (item.value*item.Product.price);
            }
            
            return View(model);
        }
        
        public ActionResult GetCart()
        {
            var userId = User.Identity.GetUserId();

            int count = 0;
            if (userId!=null)
            {
                count = context.Carts.Where(p => p.userId == userId).ToList().Count;
            }
            
            return PartialView("_FloatCartPartial",count);
        }

        [Authorize]
        public ActionResult AddCart(String url,int productId, int val)
        {
            Cart cart = new Cart();
            
            cart.productId = productId;
            cart.userId = User.Identity.GetUserId();

            var updb = context.Carts.Where(p => p.userId == cart.userId && p.productId == productId).FirstOrDefault();
            if (updb!=null)
            {
                cart.value = val + updb.value;
            }
            else
            {
                cart.value = val;
            }

            context.Carts.AddOrUpdate(cart);
            context.SaveChanges();
            return Redirect(url);
        }
    }
}