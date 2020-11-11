using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class CommonInterestRate
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal InterestRate { get; set; }

    }
}
