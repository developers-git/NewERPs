namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CourseFeePayment_Join
    {
        [Key]
        public int CFPJ_Id { get; set; }

        public int? C_PaymentID { get; set; }

        [StringLength(100)]
        public string FeeName { get; set; }

        public decimal? Fee { get; set; }

        public virtual CourseFeePayment CourseFeePayment { get; set; }
    }
}
