namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cards_Staff
    {
        public int StaffID { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        public int Id { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
