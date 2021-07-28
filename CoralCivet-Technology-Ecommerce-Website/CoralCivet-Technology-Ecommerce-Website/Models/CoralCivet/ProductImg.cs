namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductImg")]
    public partial class ProductImg
    {

        public int Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? type { get; set; }

        public int productId { get; set; }

        public virtual Product Product { get; set; }
    }
}
