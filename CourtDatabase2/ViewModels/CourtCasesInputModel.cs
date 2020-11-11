using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.ViewModels
{
    public class CourtCasesInputModel //Id,CourtId,LawCaseId,CaseNumber,CaseYear,CourtChamber,CaseType
    {
        public int CourtId { get; set; }

        public int LawCaseId { get; set; }

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
