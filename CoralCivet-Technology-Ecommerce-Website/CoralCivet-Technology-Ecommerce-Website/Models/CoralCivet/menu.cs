namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("menu")]
    public partial class menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public menu()
        {
            menu1 = new HashSet<menu>();
        }

        public int ID { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string link { get; set; }

        public int? tableid { get; set; }

        public int parentid { get; set; }

        public int orders { get; set; }

        public string position { get; set; }

        public DateTime? created_at { get; set; }

        [StringLength(128)]
        public string created_by { get; set; }

        public DateTime? updated_at { get; set; }

        [StringLength(128)]
        public string updated_by { get; set; }

        public int status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<menu> menu1 { get; set; }

        public virtual menu menu2 { get; set; }
    }
}
