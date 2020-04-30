namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostelInfo")]
    public partial class HostelInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HostelInfo()
        {
            Hostelers = new HashSet<Hosteler>();
            Installment_Hostel = new HashSet<Installment_Hostel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HI_Id { get; set; }

        [StringLength(100)]
        public string Hostelname { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string ContactNo { get; set; }

        [StringLength(100)]
        public string ManagedBy { get; set; }

        [StringLength(100)]
        public string Person_ContactNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hosteler> Hostelers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Installment_Hostel> Installment_Hostel { get; set; }
    }
}
