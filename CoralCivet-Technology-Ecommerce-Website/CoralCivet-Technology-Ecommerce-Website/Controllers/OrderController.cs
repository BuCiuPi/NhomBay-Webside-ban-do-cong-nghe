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
    public class OrderController : Controller
    {
        // GET: Order
        ApplicationDbContext db = new ApplicationDbContext();
        CoralCivetContext context = new CoralCivetContext();

        public ActionResult Index(List<Cart> input)
        {
            OrderIndex model = new OrderIndex();
            db.Roles.ToList();
            var user = db.Roles.First();

            foreach (var item in input)
            {
                
                ordersdetail temp = new ordersdetail();
                temp.Product = context.Products.FirstOrDefault(p => p.ID == item.productId);
                temp.productid = item.productId;
                temp.quantity = item.value;

                model.orderDetailList.Add(temp);
            }
            return View(model);
        }

        [ActionName("IndexAProduct")]
        public ActionResult Index(Cart input)
        {
            OrderIndex model = new OrderIndex();
            model.orderDetailList = new List<ordersdetail>();

            ordersdetail temp = new ordersdetail();
            temp.Product = context.Products.FirstOrDefault(p => p.ID == input.productId);
            temp.productid = input.productId;
            temp.quantity = input.value;

            model.orderDetailList.Add(temp);

            return View("Index",model);
        }

        public ActionResult View()
        {
            return View("View");
        }
    }
}