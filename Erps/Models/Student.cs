namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            CourseFeePayments = new HashSet<CourseFeePayment>();
            Discounts = new HashSet<Discount>();
            NoDues_Student = new HashSet<NoDues_Student>();
            StudentDocSubmitteds = new HashSet<StudentDocSubmitted>();
        }

        [Key]
        [StringLength(100)]
        public string AdmissionNo { get; set; }

        [StringLength(100)]
        public string EnrollmentNo { get; set; }

        [StringLength(100)]
        public string GRNo { get; set; }

        [StringLength(100)]
        public string UID { get; set; }

        [StringLength(100)]
        public string StudentName { get; set; }

        [StringLength(100)]
        public string FatherName { get; set; }

        [StringLength(100)]
        public string MotherName { get; set; }

        [StringLength(100)]
        public string FatherCN { get; set; }

        [StringLength(100)]
        public string PermanentAddress { get; set; }

        [StringLength(100)]
        public string TemporaryAddress { get; set; }

        [StringLength(100)]
        public string ContactNo { get; set; }

        [StringLength(100)]
        public string EmailID { get; set; }

        [StringLength(100)]
        public string DOB { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string AdmissionDate { get; set; }

        [StringLength(100)]
        public string Session { get; set; }

        [StringLength(100)]
        public string Caste { get; set; }

        [StringLength(100)]
        public string Religion { get; set; }

        public int? SectionID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }

        public int? SchoolID { get; set; }

        [StringLength(100)]
        public string LastSchoolAttended { get; set; }

        [StringLength(100)]
        public string Result { get; set; }

        [StringLength(100)]
        public string PassPercentage { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseFeePayment> CourseFeePayments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discount> Discounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoDues_Student> NoDues_Student { get; set; }

        public virtual SchoolInfo SchoolInfo { get; set; }

        public virtual Section Section { get; set; }

        public virtual Section Section1 { get; set; }

        public virtual Session_Master Session_Master { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentDocSubmitted> StudentDocSubmitteds { get; set; }
    }
}
