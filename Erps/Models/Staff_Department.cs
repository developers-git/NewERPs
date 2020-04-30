namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Staff_Department
    {
        [Key]
        public int SD_ID { get; set; }

        public int? DepartmentID { get; set; }

        public int? StaffID { get; set; }

        public virtual Department Department { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
