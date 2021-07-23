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
        CoralCivetContext context = new CoralCivetContext();

        public ActionResult Index(List<ordersdetail> input)
        {
            OrderIndex model = new OrderIndex();
            model.orderList = input;
            return View(model);
        }

        [ActionName("IndexAProduct")]
        public ActionResult Index(ordersdetail input)
        {
            OrderIndex model = new OrderIndex();
            model.orderList = new List<ordersdetail>();

            ordersdetail temp = input;
            temp.Product = context.Products.FirstOrDefault(p => p.ID == input.productid);

            model.orderList.Add(temp);

            return View("Index",model);
        }
    }
}