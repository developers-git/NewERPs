namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdvanceEntry")]
    public partial class AdvanceEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? StaffID { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Deduction { get; set; }

        public DateTime? WorkingDate { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
