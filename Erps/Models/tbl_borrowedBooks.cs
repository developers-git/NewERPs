namespace Erps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_borrowedBooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Book_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Borrower_ID { get; set; }

        [StringLength(300)]
        public string Purpose { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_Taken { get; set; }

        [Column(TypeName = "date")]
        public DateTime Return_Date { get; set; }

        [StringLength(30)]
        public string Status { get; set; }
    }
}
