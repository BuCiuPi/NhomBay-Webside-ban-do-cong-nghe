namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Type")]
    public partial class Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type()
        {
            Products = new HashSet<Product>();
            Type1 = new HashSet<Type>();
            TypeDetails = new HashSet<TypeDetail>();
        }

        public int ID { get; set; }

        public string name { get; set; }

        public string slug { get; set; }

        public int? parentid { get; set; }

        public int orders { get; set; }

        public string metakey { get; set; }

        public string metadesc { get; set; }

        public DateTime? created_at { get; set; }

        [StringLength(128)]
        public string created_by { get; set; }

        public DateTime? updated_at { get; set; }

        [StringLength(128)]
        public string updated_by { get; set; }

        public int status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type> Type1 { get; set; }

        public virtual Type Type2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeDetail> TypeDetails { get; set; }
    }
}
