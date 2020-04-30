namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activation")]
    public partial class Activation
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string HardwareID { get; set; }

        [StringLength(100)]
        public string SerialNo { get; set; }

        [StringLength(100)]
        public string ActivationID { get; set; }
    }
}
