namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("slider")]
    public partial class slider
    {
        public int ID { get; set; }

        public string name { get; set; }

        public string url { get; set; }

        public string position { get; set; }

        public string img { get; set; }

        public int? orders { get; set; }

        public DateTime? created_at { get; set; }

        [StringLength(128)]
        public string created_by { get; set; }

        public DateTime? updated_at { get; set; }

        [StringLength(128)]
        public string updated_by { get; set; }

        public int status { get; set; }
    }
}
