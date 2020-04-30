namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDepartment")]
    public partial class tblDepartment
    {
        [StringLength(100)]
        public string Department { get; set; }

        [Key]
        public int DepartmentID { get; set; }
    }
}
