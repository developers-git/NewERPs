namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qrySectionAdvisory")]
    public partial class qrySectionAdvisory
    {
        [Key]
        [StringLength(100)]
        public string SectionID { get; set; }

        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(100)]
        public string newSection { get; set; }

        [StringLength(100)]
        public string SectionName { get; set; }

        [StringLength(100)]
        public string YearLvl { get; set; }

        [StringLength(100)]
        public string YrLvlChar { get; set; }

        [StringLength(100)]
        public string MaxStudent { get; set; }

        [StringLength(100)]
        public string MaxGrade { get; set; }

        [StringLength(100)]
        public string MinGrade { get; set; }

        [StringLength(100)]
        public string Faculty { get; set; }
    }
}
