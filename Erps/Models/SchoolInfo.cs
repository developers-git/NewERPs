namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolInfo")]
    public partial class SchoolInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SchoolInfo()
        {
            CourseFees = new HashSet<CourseFee>();
            CourseFees1 = new HashSet<CourseFee>();
            Installment_Hostel = new HashSet<Installment_Hostel>();
            Staffs = new HashSet<Staff>();
            Students = new HashSet<Student>();
            Vouchers = new HashSet<Voucher>();
        }

        [Key]
        public int S_Id { get; set; }

        [StringLength(100)]
        public string SchoolName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string ContactNo { get; set; }

        [StringLength(100)]
        public string AltContactNo { get; set; }

        [StringLength(100)]
        public string FaxNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [StringLength(100)]
        public string RegistrationNo { get; set; }

        [StringLength(100)]
        public string DiseNo { get; set; }

        [StringLength(100)]
        public string IndexNo { get; set; }

        public int? EstablishedYear { get; set; }

        [StringLength(100)]
        public string Class { get; set; }

        [StringLength(100)]
        public string SchoolType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseFee> CourseFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseFee> CourseFees1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Installment_Hostel> Installment_Hostel { get; set; }
        [ForeignKey("SchoolType")]
        public virtual SchoolType SchoolType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
