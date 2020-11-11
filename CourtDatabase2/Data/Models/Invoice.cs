using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Number { get; set; } // № на фактурата

        public DateTime IssueDate { get; set; }// Дата на издаване

        [Range(0, 79228162514264337593543935D)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; } // Стойност

        public DateTime Maturity { get; set; } // Падеж

        public DateTime PeriodSince { get; set; } // Период от

        public DateTime PeriodTo { get; set; } // Период до

        [ForeignKey(nameof(HeatEstate))]
        public string AbNumber { get; set; }
        public virtual HeatEstate HeatEstate { get; set; } // Топлоснабден обект

        [ForeignKey(nameof(Debitor))]
        public int DebitorId { get; set; }
        public virtual Debitor Debitor { get; set; } // Длъжник

        [Required]
        [MaxLength(30)]
        public string Condition { get; set; }
    }
}
