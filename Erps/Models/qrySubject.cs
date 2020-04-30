namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class qrySubject
    {
        [Key]
        [StringLength(100)]
        public string SubjectCode { get; set; }

        [StringLength(100)]
        public string DescriptiveTitle { get; set; }

        [StringLength(100)]
        public string YearLevel { get; set; }

        [StringLength(100)]
        public string DepartmentID { get; set; }

        [StringLength(100)]
        public string Units { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(100)]
        public string YrLvlChar { get; set; }
    }
}
