namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ordersdetail")]
    public partial class ordersdetail
    {
        public int Id { get; set; }

        public int orderId { get; set; }

        public int productid { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public int priceSale { get; set; }

        public double amount { get; set; }

        public virtual order order { get; set; }

        public virtual Product Product { get; set; }
    }
}
