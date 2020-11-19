using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Payee { get; set; }

        [Required]
        [MaxLength(100)]
        public string ExpenceDescription { get; set; }

        [Range(0.01, 100_000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExpenceValue { get; set; }

        public DateTime ExpenceDate { get; set; }

        [ForeignKey(nameof(LawCase))]
        public int LawCaseId { get; set; }
        public virtual LawCase LawCase { get; set; }

    }
}
