﻿using CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoralCivet_Technology_Ecommerce_Website.Models.CustomModels
{
    public class HomeIndex
    {
        public List<slider> sliders { get; set; }
        public List<Product> products { get; set; }
        public List<CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet.Type> types { get; set; }
    }
}