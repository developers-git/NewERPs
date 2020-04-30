namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostelFeePayment")]
    public partial class HostelFeePayment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? HFP_Id { get; set; }

        [StringLength(100)]
        public string PaymentID { get; set; }

        public int? HostelerID { get; set; }

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

        public DateTime? Paymentdate { get; set; }

        public decimal? PaymentDue { get; set; }

        [StringLength(100)]
        public string ClassType { get; set; }

        [StringLength(100)]
        public string SchoolType { get; set; }

        [StringLength(100)]
        public string Class { get; set; }

        [StringLength(100)]
        public string Section { get; set; }

        public virtual Hosteler Hosteler { get; set; }
    }
}
