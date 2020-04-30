namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subjectID { get; set; }

        [Key]
        [MaxLength(50)]
        public byte[] subjectName { get; set; }

        [StringLength(50)]
        public string Grade1 { get; set; }

        [StringLength(50)]
        public string Grade2 { get; set; }

        [StringLength(50)]
        public string Grade3 { get; set; }

        [StringLength(50)]
        public string Grade4 { get; set; }

        [StringLength(50)]
        public string Grade5 { get; set; }

        [StringLength(50)]
        public string Grade6 { get; set; }

        [StringLength(50)]
        public string Grade7 { get; set; }

        [StringLength(50)]
        public string SpecialClass { get; set; }

        [StringLength(50)]
        public string Other { get; set; }
    }
}
