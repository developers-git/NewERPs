namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NoDues_Student
    {
        [Required]
        [StringLength(100)]
        public string AdmissionNo { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        public int Id { get; set; }

        public virtual Student Student { get; set; }
    }
}
