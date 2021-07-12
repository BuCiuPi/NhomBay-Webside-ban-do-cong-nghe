namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("post")]
    public partial class post
    {
        public int ID { get; set; }

        public int? topid { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        [StringLength(255)]
        public string slug { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        [StringLength(255)]
        public string img { get; set; }

        [Required]
        public string descriptionShort { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [Required]
        [StringLength(150)]
        public string metakey { get; set; }

        [Required]
        [StringLength(150)]
        public string metadesc { get; set; }

        public DateTime? created_at { get; set; }

        [StringLength(128)]
        public string created_by { get; set; }

        public DateTime? updated_at { get; set; }

        [StringLength(128)]
        public string updated_by { get; set; }

        public int status { get; set; }

        public virtual topic topic { get; set; }
    }
}
