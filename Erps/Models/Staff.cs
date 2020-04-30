namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            AdvanceEntries = new HashSet<AdvanceEntry>();
            BusCardHolder_Staff = new HashSet<BusCardHolder_Staff>();
            Cards_Staff = new HashSet<Cards_Staff>();
            NoDues_Staff = new HashSet<NoDues_Staff>();
            Discount_Staff = new HashSet<Discount_Staff>();
            Staff_Department = new HashSet<Staff_Department>();
            StaffAttendances = new HashSet<StaffAttendance>();
            StaffPayments = new HashSet<StaffPayment>();
        }

        [Key]
        public int St_ID { get; set; }

        [StringLength(100)]
        public string StaffID { get; set; }

        [StringLength(100)]
        public string StaffName { get; set; }

        public DateTime? DateOfJoining { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string FatherName { get; set; }

        [StringLength(100)]
        public string TemporaryAddress { get; set; }

        [StringLength(100)]
        public string PermanentAddress { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        [StringLength(100)]
        public string Qualifications { get; set; }

        [StringLength(100)]
        public string DOB { get; set; }

        [StringLength(100)]
        public string PhoneNo { get; set; }

        [StringLength(100)]
        public string MobileNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [StringLength(100)]
        public string ClassType { get; set; }

        public int? SchoolID { get; set; }

        [StringLength(100)]
        public string AccountName { get; set; }

        [StringLength(100)]
        public string AccountNumber { get; set; }

        [StringLength(100)]
        public string Bank { get; set; }

        [StringLength(100)]
        public string Branch { get; set; }

        [StringLength(100)]
        public string IFSCCode { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        public decimal? Salary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvanceEntry> AdvanceEntries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusCardHolder_Staff> BusCardHolder_Staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cards_Staff> Cards_Staff { get; set; }

        public virtual ClassType ClassType1 { get; set; }

        public virtual Designation Designation1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoDues_Staff> NoDues_Staff { get; set; }

        public virtual SchoolInfo SchoolInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discount_Staff> Discount_Staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff_Department> Staff_Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffAttendance> StaffAttendances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffPayment> StaffPayments { get; set; }
    }
}
