namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qrySubjectOfferring")]
    public partial class qrySubjectOfferring
    {
        [Key]
        [StringLength(100)]
        public string SubjectOfferingID { get; set; }

        [StringLength(100)]
        public string SubjectCode { get; set; }

        [StringLength(100)]
        public string SectionID { get; set; }

        [StringLength(100)]
        public string cTimeIn { get; set; }

        [StringLength(100)]
        public string cTimeOut { get; set; }

        [StringLength(100)]
        public string cRoom { get; set; }

        [StringLength(100)]
        public string cDay { get; set; }

        [StringLength(100)]
        public string FacultyID { get; set; }

        [StringLength(100)]
        public string DescriptiveTitle { get; set; }

        [StringLength(100)]
        public string Schedule { get; set; }

        [StringLength(100)]
        public string Faculty { get; set; }

        [StringLength(100)]
        public string Section { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(100)]
        public string Units { get; set; }
    }
}
