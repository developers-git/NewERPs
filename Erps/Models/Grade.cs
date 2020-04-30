namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grade
    {
        [Key]
        [Column("Grade")]
        [StringLength(100)]
        public string Grade1 { get; set; }

        [StringLength(100)]
        public string ScoreFrom { get; set; }

        [StringLength(100)]
        public string ScoreTo { get; set; }

        [StringLength(100)]
        public string GradePoint { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}
