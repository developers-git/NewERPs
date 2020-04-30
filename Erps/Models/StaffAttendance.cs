namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaffAttendance")]
    public partial class StaffAttendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? WorkingDate { get; set; }

        public int? StaffID { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength(100)]
        public string InTime { get; set; }

        [StringLength(100)]
        public string OutTime { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
