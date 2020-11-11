using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class LawCase
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(Debitor))]
        public int DebitorId { get; set; }
        public virtual Debitor Debitor { get; set; }

        [ForeignKey(nameof(Obligation))]
        public int ObligationId { get; set; }
        public virtual Obligation Obligation { get; set; }

        [ForeignKey(nameof(HeatEstate))]
        public string AbNumber { get; set; }
        public virtual HeatEstate HeatEstate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MoratoriumInterest { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LegalInterest { get; set; }

        public virtual ICollection<ExecutorCase> ExecutorCases => new HashSet<ExecutorCase>();

        public virtual ICollection<CourtCase> Courts => new HashSet<CourtCase>();

        public virtual ICollection<Expense> Expenses => new HashSet<Expense>();

        public virtual ICollection<CaseAction> Actions => new HashSet<CaseAction>();
    }
}
