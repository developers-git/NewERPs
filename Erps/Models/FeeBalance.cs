namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FeeBalance
    {
        public int id { get; set; }

        [StringLength(100)]
        public string AdmissionNo { get; set; }

        [StringLength(100)]
        public string Session { get; set; }

        [StringLength(100)]
        public string Semester { get; set; }

        [StringLength(100)]
        public string Fee { get; set; }

        [StringLength(100)]
        public string PreviousDue { get; set; }

        [StringLength(100)]
        public string TotalPayment { get; set; }

        [StringLength(100)]
        public string Balance { get; set; }
    }
}
