namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Installment_Hostel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IH_ID { get; set; }

        [StringLength(100)]
        public string Installment { get; set; }

        public decimal? Charges { get; set; }

        public int? HostelID { get; set; }

        [StringLength(100)]
        public string Class { get; set; }

        public int? SchoolID { get; set; }

        public virtual Class Class1 { get; set; }

        public virtual HostelInfo HostelInfo { get; set; }

        public virtual SchoolInfo SchoolInfo { get; set; }
    }
}
