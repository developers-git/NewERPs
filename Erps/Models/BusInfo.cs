namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BusInfo")]
    public partial class BusInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusInfo()
        {
            BusCardHolder_Staff = new HashSet<BusCardHolder_Staff>();
            BusCardHolder_Student = new HashSet<BusCardHolder_Student>();
        }

        [Key]
        [StringLength(100)]
        public string BusNo { get; set; }

        [StringLength(100)]
        public string DriverName { get; set; }

        [StringLength(100)]
        public string ContactNo { get; set; }

        [StringLength(100)]
        public string SupporterName { get; set; }

        [StringLength(100)]
        public string S_ContactNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusCardHolder_Staff> BusCardHolder_Staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusCardHolder_Student> BusCardHolder_Student { get; set; }
    }
}
