﻿using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
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
                item.amount = item.Product.price*item.value;
            }
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
            cart.IsSelected = false;

            var updb = context.Carts.Where(p => p.userId == cart.userId && p.productId == productId).FirstOrDefault();
            if (updb!=null)
            {
                if (updb.value > 0 ||  val > 0)
                {
                    cart.value = val + updb.value;
                }
                else
                {
                    cart.value = updb.value;
                }
                
            }
            else
            {
                cart.value = val;
            }

            context.Carts.AddOrUpdate(cart);
            context.SaveChanges();
            return Redirect(url);
        }


        public ActionResult DelCart(int productId)
        {
            Cart cart = new Cart();

            cart.productId = productId;
            cart.userId = User.Identity.GetUserId();

            var updb = context.Carts.FirstOrDefault(p => p.userId == cart.userId && p.productId == productId);
            if (updb!=null)
            {
                context.Carts.Remove(updb);
                context.SaveChanges();
            }
            return RedirectToAction("Index","Cart");
        }

        public ActionResult SetSelected(int productId,bool value)
        {
            var userID = User.Identity.GetUserId();

            var db = context.Carts.First(p=>p.productId == productId && p.userId == userID);
            if (db!=null)
            {
                db.IsSelected = value;
                context.Carts.AddOrUpdate(db);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}