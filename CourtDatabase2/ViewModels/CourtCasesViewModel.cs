using CourtDatabase2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.ViewModels
{
    public class CourtCasesViewModel 
    {
        [Display(Name = "Дело ИД")]
        public int Id { get; set; }

        public int CourtId { get; set; }
        public Court Court { get; set; }

        public string Debitor { get; set; }

        [Display(Name = "Съд")]
        public string CourtName { get; set; }

        [Display(Name = "Гр. Дело ИД")]
        public int LawCaseId { get; set; }
        public LawCase LawCase { get; set; }

        [Display(Name = "Дело № ")]
        public int CaseNumber { get; set; }

        [Display(Name = "Дело година")]
        [Range(2000, 2050)]
        public int CaseYear { get; set; }

        [Display(Name = "Съдебна инстанция")]
        public string CourtChamber { get; set; }

        [Display(Name = "Вид дело")]
        public string CaseType { get; set; }

    }
}
