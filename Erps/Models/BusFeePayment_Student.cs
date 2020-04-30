namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BusFeePayment_Student
    {
        public int Id { get; set; }

        public int? BFP_ID { get; set; }

        [StringLength(100)]
        public string PaymentID { get; set; }

        public int? BusHolderID { get; set; }

        [StringLength(100)]
        public string Session { get; set; }

        [StringLength(100)]
        public string Installment { get; set; }

        public decimal? TotalFee { get; set; }

        public decimal? DiscountPer { get; set; }

        public decimal? DiscountAmt { get; set; }

        public decimal? PreviousDue { get; set; }

        public decimal? Fine { get; set; }

        public decimal? GrandTotal { get; set; }

        public decimal? TotalPaid { get; set; }

        [StringLength(100)]
        public string ModeOfPayment { get; set; }

        [StringLength(100)]
        public string PaymentModeDetails { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal? PaymentDue { get; set; }

        [StringLength(100)]
        public string ClassType { get; set; }

        [StringLength(100)]
        public string SchoolType { get; set; }

        [StringLength(100)]
        public string Class { get; set; }

        [StringLength(100)]
        public string Section { get; set; }

        public virtual BusCardHolder_Student BusCardHolder_Student { get; set; }
    }
}
