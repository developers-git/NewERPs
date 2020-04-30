namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string UserID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(500)]
        public string Operation { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
