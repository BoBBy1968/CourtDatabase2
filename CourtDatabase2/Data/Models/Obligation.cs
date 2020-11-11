using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class Obligation
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 79228162514264337593543935D)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        public DateTime PeriodFrom { get; set; }

        public DateTime PeriodTo { get; set; }

        [Range(0, int.MaxValue)]
        public int InvoiceCount { get; set; }

        [ForeignKey(nameof(LawCase))]
        public int? LawCaseId { get; set; }
        public virtual LawCase LawCase { get; set; }

        public virtual ICollection<Payment> Payments => new HashSet<Payment>();
    }
}
