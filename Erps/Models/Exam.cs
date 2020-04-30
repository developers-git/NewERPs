namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exam
    {
        [Key]
        public int exam_id { get; set; }

        [StringLength(100)]
        public string exam_type { get; set; }

        [StringLength(100)]
        public string exam_name { get; set; }

        [StringLength(100)]
        public string subject { get; set; }

        [StringLength(100)]
        public string total_marks { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [StringLength(100)]
        public string examiner { get; set; }

        [StringLength(100)]
        public string class_name { get; set; }

        [StringLength(100)]
        public string semester { get; set; }

        [StringLength(100)]
        public string session { get; set; }

        [Column(TypeName = "date")]
        public DateTime? exam_time { get; set; }

        [Column(TypeName = "date")]
        public DateTime? exam_date { get; set; }
    }
}
