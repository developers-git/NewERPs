namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BusCardHolder_Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusCardHolder_Student()
        {
            BusFeePayment_Student = new HashSet<BusFeePayment_Student>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BCH_Id { get; set; }

        [StringLength(100)]
        public string AdmissionNo { get; set; }

        [StringLength(100)]
        public string BusNo { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        public DateTime? JoiningDate { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        public virtual BusInfo BusInfo { get; set; }

        public virtual Location Location1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusFeePayment_Student> BusFeePayment_Student { get; set; }
    }
}
