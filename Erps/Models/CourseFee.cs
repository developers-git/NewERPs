namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseFee")]
    public partial class CourseFee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C_ID { get; set; }

        public int? SchoolID { get; set; }

        [StringLength(100)]
        public string Class { get; set; }

        [StringLength(100)]
        public string FeeName { get; set; }

        [Required]
        [StringLength(100)]
        public string Semester { get; set; }

        public decimal? Fee { get; set; }

        public virtual Class Class1 { get; set; }

        public virtual Fee Fee1 { get; set; }

        public virtual SchoolInfo SchoolInfo { get; set; }

        public virtual SchoolInfo SchoolInfo1 { get; set; }
    }
}
