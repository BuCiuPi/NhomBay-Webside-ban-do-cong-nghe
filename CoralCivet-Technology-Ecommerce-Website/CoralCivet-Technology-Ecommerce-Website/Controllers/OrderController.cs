using CoralCivet_Technology_Ecommerce_Website.Models;
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
    public class OrderController : Controller
    {
        // GET: Order
        CoralCivetContext context = new CoralCivetContext();

        public ActionResult Index()
        {
            OrderIndex model = new OrderIndex();
            model.orderDetailList = new List<ordersdetail>();

            var user = User.Identity.GetUserId();

            foreach (var item in context.Carts.Where(p=>p.userId == user && p.IsSelected == true).ToList())
            {
                
                ordersdetail temp = new ordersdetail();
                temp.Product = context.Products.FirstOrDefault(p => p.ID == item.productId);
                temp.productid = item.productId;
                temp.price = temp.Product.price;
                temp.quantity = item.value;
                temp.amount = temp.price * temp.quantity;

                model.orderDetailList.Add(temp);

                model.total += temp.amount;
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
            temp.price = temp.Product.price;
            temp.quantity = input.value;
            temp.amount = temp.price*temp.quantity;

            model.orderDetailList.Add(temp);

            model.total += temp.amount;

            return View("Index",model);
        }
        
        [HttpPost]
        [ActionName("Index")]
        public ActionResult ConfirmOrder(OrderIndex model)
        {
            var user = User.Identity.GetUserId();

            model.order.created_at = DateTime.Now;
            model.order.update_at = DateTime.Now;
            model.order.status = 0;
            model.order.userId = user;
            if (model.order.deliveryPaymentMethod == "COD")
            {
                model.order.StatusPayment = 0;
            }
            else
            {
                model.order.StatusPayment = 1;
            }

            var order = context.orders.Add(model.order);
            context.SaveChanges();


            model.orderDetailList = new List<ordersdetail>();
            
            var ListCart = context.Carts.Where(p => p.userId == user && p.IsSelected == true).ToList();
            foreach (var item in ListCart)
            {
                ordersdetail temp = new ordersdetail();
                temp.orderId = order.Id;
                temp.productid = item.productId;
                temp.quantity = item.value;
                temp.price = item.Product.price;
                temp.amount = item.Product.price * item.value;
                context.ordersdetails.Add(temp);
                context.SaveChanges();
            }

            order.totalSum = 0;
            foreach (var item in order.ordersdetails)
            {
                order.totalSum += item.amount;
            }

            context.orders.AddOrUpdate(model.order);
            context.SaveChanges();

            return View("Done",order.Id);
        }

        public ActionResult Done(int? orderId)
        {
            if (orderId!=null)
            {
                return View("Done", context.orders.FirstOrDefault(p => p.Id == orderId));
            }
            return View("Done");
        }
    }
}