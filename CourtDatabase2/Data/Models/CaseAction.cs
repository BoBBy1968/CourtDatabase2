using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class CaseAction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(LegalAction))]
        public int LegalActionId { get; set; }
        public virtual LegalAction LegalAction { get; set; }

        [ForeignKey(nameof(LawCase))]
        public int LawCaseId { get; set; }
        public virtual LawCase LawCase { get; set; }

        public DateTime Date { get; set; }
    }
}
