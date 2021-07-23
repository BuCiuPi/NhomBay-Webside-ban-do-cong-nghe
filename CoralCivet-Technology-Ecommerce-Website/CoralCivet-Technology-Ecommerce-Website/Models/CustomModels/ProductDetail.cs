using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoralCivet_Technology_Ecommerce_Website.Models.CustomModels
{
    public class ProductDetail
    {
        public Product products { get; set; }

        public List<TypeDetail> typeDetails { get; set; }

        public List<ProductImg> imgs { get; set; }


        public List<Product> orderProducts { get; set; }
    }
}