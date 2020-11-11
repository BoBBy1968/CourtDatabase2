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

        [Display(Name = "Дело № ")]
        public int CaseNumber { get; set; }

        [Display(Name = "Дело година")]
        [DataType(DataType.Date)]
        public DateTime CaseYear { get; set; }

        [Display(Name = "Съдебна инстанция")]
        public string CourtChamber { get; set; }

        [Display(Name = "Вид дело")]
        public CaseType CaseType { get; set; }

    }
}
