﻿using CoralCivet_Technology_Ecommerce_Website.Models;
using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
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

            ViewBag.Types = context.Types.Where(p => p.parentId == null).ToList();
            ViewBag.Products = context.Products.ToList().Take(4);
            return View(context.sliders.Where(p => p.status == 1).ToList());
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

        public ActionResult Cart()
        {

            return View();
        }

        public ActionResult Order()
        {

            return View();
        }
    }
}