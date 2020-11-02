using CourtDatabase2.Data.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class CourtCase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Court))]
        public int CourtId { get; set; }
        public virtual Court Court { get; set; }


        [ForeignKey(nameof(LawCase))]
        public int LawCaseId { get; set; }
        public virtual LawCase LawCase { get; set; }

        public int CaseNumber { get; set; }

        public DateTime CaseYear { get; set; }

        public string CourtChamber { get; set; }

        public CaseType CaseType { get; set; }

    }
}
