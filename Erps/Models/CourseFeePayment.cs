namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseFeePayment")]
    public partial class CourseFeePayment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseFeePayment()
        {
            CourseFeePayment_Join = new HashSet<CourseFeePayment_Join>();
        }

        public int Id { get; set; }

        public int? CFP_ID { get; set; }

        [StringLength(100)]
        public string PaymentID { get; set; }

        [StringLength(100)]
        public string AdmissionNo { get; set; }

        [StringLength(100)]
        public string Session { get; set; }

        [StringLength(100)]
        public string Semester { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseFeePayment_Join> CourseFeePayment_Join { get; set; }

        public virtual Student Student { get; set; }
    }
}
