namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_subjects
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subject_id { get; set; }

        [Key]
        [StringLength(50)]
        public string subject_name { get; set; }

        [Required]
        [StringLength(50)]
        public string subject_status { get; set; }
    }
}
