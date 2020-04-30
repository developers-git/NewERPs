namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        public int PermissionID { get; set; }

        public string ControllerName { get; set; }

        public string ViewName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string assignedRole { get; set; }

        [Required]
        public string Module { get; set; }

        public bool IsDashboard { get; set; }

        public bool IsWebForm { get; set; }

        public string webFormUrl { get; set; }

        public bool IsActice { get; set; }
    }
}
