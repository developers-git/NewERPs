namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            Logs = new HashSet<Log>();
        }

        [Key]
        [StringLength(100)]
        public string UserID { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Usertype { get; set; }

        [StringLength(100)]
        public string ContactNo { get; set; }

        [StringLength(100)]
        public string EmailID { get; set; }

        public DateTime? JoiningDate { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength(100)]
        public string TwoWayAuth { get; set; }

        [StringLength(100)]
        public string AuthCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log> Logs { get; set; }
    }
}
