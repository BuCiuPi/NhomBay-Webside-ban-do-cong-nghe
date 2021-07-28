using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoralCivet_Technology_Ecommerce_Website.Models.CustomModels
{
    public class CartIndex
    {
        public List<Cart> Carts { get; set; }
        public double total;
    }
}