namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaffPayment")]
    public partial class StaffPayment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string PaymentID { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? StaffID { get; set; }

        public int? PresentDays { get; set; }

        public decimal? Salary { get; set; }

        public decimal? Advance { get; set; }

        public decimal? Deduction { get; set; }

        public DateTime? PaymentDate { get; set; }

        [StringLength(100)]
        public string ModeOfPayment { get; set; }

        [StringLength(100)]
        public string PaymentModeDetails { get; set; }

        public decimal? NetPay { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
