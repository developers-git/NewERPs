namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mark
    {
        [Key]
        public int mark_id { get; set; }

        [StringLength(100)]
        public string admission_number { get; set; }

        public int? subject_id { get; set; }

        [Column("mark")]
        [StringLength(100)]
        public string mark1 { get; set; }

        [StringLength(100)]
        public string grade { get; set; }

        [StringLength(100)]
        public string comment { get; set; }

        [StringLength(100)]
        public string semester { get; set; }

        [StringLength(100)]
        public string session { get; set; }

        public int? exam_id { get; set; }
    }
}
