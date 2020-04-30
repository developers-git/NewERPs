namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qryFaculty")]
    public partial class qryFaculty
    {
        [Key]
        [StringLength(100)]
        public string FacultyName { get; set; }

        [StringLength(100)]
        public string FacultyID { get; set; }

        [StringLength(100)]
        public string OnService { get; set; }
    }
}
