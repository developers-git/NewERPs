namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BusFeePayment_Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public virtual BusCardHolder_Staff BusCardHolder_Staff { get; set; }
    }
}
