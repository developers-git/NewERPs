namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hosteler")]
    public partial class Hosteler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hosteler()
        {
            HostelFeePayments = new HashSet<HostelFeePayment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int H_Id { get; set; }

        [StringLength(100)]
        public string AdmissionNo { get; set; }

        public int? HostelID { get; set; }

        public DateTime? JoiningDate { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        public virtual HostelInfo HostelInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HostelFeePayment> HostelFeePayments { get; set; }
    }
}
