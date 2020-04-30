namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Discount_Staff
    {
        public int Id { get; set; }

        public int? StaffID { get; set; }

        public decimal? Discount { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
