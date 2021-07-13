namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            ordersdetails = new HashSet<ordersdetail>();
        }

        public int Id { get; set; }

        public string code { get; set; }

        [StringLength(128)]
        public string userId { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? exportdate { get; set; }

        public string deliveryaddress { get; set; }

        public string deliveryname { get; set; }

        public string deliveryphone { get; set; }

        public string deliveryemail { get; set; }

        public string deliveryPaymentMethod { get; set; }

        public int StatusPayment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? update_at { get; set; }

        [StringLength(128)]
        public string update_by { get; set; }

        public int status { get; set; }

        public double? totalSum { get; set; }

        public double? transport_fee { get; set; }

        [StringLength(50)]
        public string transport_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordersdetail> ordersdetails { get; set; }
    }
}
