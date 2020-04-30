namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_positions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int position_id { get; set; }

        [Key]
        [StringLength(50)]
        public string AdmissionNo { get; set; }

        public int total_marks { get; set; }

        public int position { get; set; }

        [Required]
        [StringLength(50)]
        public string grade { get; set; }

        [Column("class")]
        [Required]
        [StringLength(50)]
        public string _class { get; set; }
    }
}
