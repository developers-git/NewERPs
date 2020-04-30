namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [StringLength(100)]
        public string RoomID { get; set; }

        [StringLength(100)]
        public string RoomNo { get; set; }

        [StringLength(100)]
        public string Building { get; set; }

        [StringLength(100)]
        public string Capacity { get; set; }
    }
}
