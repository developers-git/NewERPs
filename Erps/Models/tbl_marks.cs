namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_marks
    {
        [Key]
        public int mark_id { get; set; }

        [Required]
        [StringLength(50)]
        public string AdmissionNo { get; set; }

        [Required]
        [StringLength(50)]
        public string subject { get; set; }

        public int mark { get; set; }

        [Required]
        [StringLength(50)]
        public string grade { get; set; }

        [Required]
        [StringLength(50)]
        public string comment { get; set; }

        [Required]
        [StringLength(50)]
        public string semester { get; set; }

        [StringLength(50)]
        public string session { get; set; }

        [StringLength(50)]
        public string exam_id { get; set; }

        [StringLength(50)]
        public string remarks { get; set; }
    }
}
