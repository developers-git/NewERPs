namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Book_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Book_Title { get; set; }

        [Required]
        [StringLength(300)]
        public string Book_Author { get; set; }

        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateRecorded { get; set; }

        [Required]
        [StringLength(50)]
        public string Book_Status { get; set; }

        [StringLength(100)]
        public string Quantity { get; set; }
    }
}
