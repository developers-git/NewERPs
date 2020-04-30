namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WebServiceAPI")]
    public partial class WebServiceAPI
    {
        public int id { get; set; }

        [StringLength(100)]
        public string Api { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string IsEnabled { get; set; }

        [StringLength(100)]
        public string IsDefault { get; set; }

        [StringLength(100)]
        public string Token { get; set; }
    }
}
