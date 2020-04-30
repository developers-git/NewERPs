namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string AdmissionNo { get; set; }

        [StringLength(100)]
        public string Feetype { get; set; }

        [Column("Discount")]
        public decimal? Discount1 { get; set; }

        public virtual Student Student { get; set; }
    }
}
