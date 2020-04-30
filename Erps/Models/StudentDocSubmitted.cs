namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentDocSubmitted")]
    public partial class StudentDocSubmitted
    {
        [Key]
        public int SDS_id { get; set; }

        [StringLength(100)]
        public string AdmissionNo { get; set; }

        public int? DocId { get; set; }

        public virtual Document Document { get; set; }

        public virtual Student Student { get; set; }
    }
}
