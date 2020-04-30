namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("glyphicon")]
    public partial class glyphicon
    {
        public int glyphiconID { get; set; }

        public string glyphiconname { get; set; }
    }
}
