namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ordersdetails = new HashSet<ordersdetail>();
            ProductImgs = new HashSet<ProductImg>();
            TypeDetails = new HashSet<TypeDetail>();
        }

        public int ID { get; set; }

        public int? catid { get; set; }

        [Required]
        public string name { get; set; }

        [StringLength(255)]
        public string slug { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        public double price { get; set; }

        public double? pricesale { get; set; }

        public int? number { get; set; }

        public int? sold { get; set; }

        public DateTime? created_at { get; set; }

        [StringLength(128)]
        public string created_by { get; set; }

        public int status { get; set; }

        public int? type { get; set; }

        public string noteAdmin { get; set; }

        public int? brandId { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordersdetail> ordersdetails { get; set; }

        public virtual Type Type1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImg> ProductImgs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeDetail> TypeDetails { get; set; }
    }
}
