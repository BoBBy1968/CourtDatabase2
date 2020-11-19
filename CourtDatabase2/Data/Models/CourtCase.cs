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
        [Range(1, 1000000)]
        public int CaseNumber { get; set; }

        [Range(2000, 2050)]
        [Display(Name = "Дело година")]
        public int CaseYear { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Съдебна инстанция")]
        public string CourtChamber { get; set; }

        [Display(Name = "Вид дело")]
        public CaseType CaseType { get; set; }

    }
}
