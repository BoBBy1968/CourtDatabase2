using System;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.Data.Models
{
    public class CommonInterestRate
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal InterestRate { get; set; }

    }
}
