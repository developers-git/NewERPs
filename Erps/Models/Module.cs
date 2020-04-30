namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Module
    {
        [Key]
        public int ModulesID { get; set; }

        [Required]
        public string ModulesName { get; set; }

        public int RoleID { get; set; }

        public string glyphicon { get; set; }

        public string ControllerName { get; set; }

        public string ViewName { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsWebForm { get; set; }

        public string webFormUrl { get; set; }

        public int MenuRank { get; set; }

        public virtual Role Role { get; set; }
    }
}
