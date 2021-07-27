using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoralCivet_Technology_Ecommerce_Website.Models.CustomModels
{
    public class OrderIndex
    {
        public order order { get; set; }
        public List<ordersdetail> orderDetailList { get; set; }
        public float total { get; set; }
    }

}