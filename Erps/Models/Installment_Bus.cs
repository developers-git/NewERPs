namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Installment_Bus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IB_ID { get; set; }

        [StringLength(100)]
        public string Installment { get; set; }

        public decimal? Charges { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        public virtual Location Location1 { get; set; }
    }
}
