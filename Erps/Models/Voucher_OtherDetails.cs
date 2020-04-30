namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Voucher_OtherDetails
    {
        [Key]
        public int VD_ID { get; set; }

        public int? VoucherID { get; set; }

        [StringLength(100)]
        public string Particulars { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
