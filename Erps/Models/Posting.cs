using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erps.Models
{
    public class Posting
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    public class PostingL
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<Accountss_Master> Questions { set; get; }
        public PostingL()
        {
            Questions = new List<Accountss_Master>();
        }
    }

    public class Accountss_Master
    {

        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
    }
    public class PostingD
    {
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        [Required]
        [DisplayName("Date Type")]
        public string DT { get; set; }
    }

    public class PostingW
    {
        [Required]
        public DateTime To { get; set; }
        [Required]
        [DisplayName("Date Type")]
        public string DT { get; set; }
    }

    public class OrderPostings
    {
        public string Id { get; set; }
        public string WebCompanyName { get; set; }
        public string WebCompanyValue { get; set; }
    }
    public class TRF
    {
        public double Mo { get; set; }

    }
}