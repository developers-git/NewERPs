namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interbank")]
    public partial class Interbank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZWLCash { get; set; }

        [StringLength(100)]
        public string Eco { get; set; }

        [StringLength(100)]
        public string Swipe { get; set; }

        [StringLength(100)]
        public string FCA { get; set; }

        [StringLength(100)]
        public string FCAZAR { get; set; }
    }
}
