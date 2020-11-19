using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.ViewModels
{
    public class CourtCasesInputModel
    {
        public int CourtId { get; set; }

        public int LawCaseId { get; set; }

        [Display(Name = "Дело № ")]
        [Range(1,1000000, ErrorMessage = "Номерът на делото трябва да бъде положително число.")]
        [Required(ErrorMessage ="Номерът е задължителен.")]
        public int CaseNumber { get; set; }

        [Display(Name = "Дело година")]
        [Range(2000, 2050, ErrorMessage = "Годината на делото трябва да бъде число между 2000 и 2050.")]
        [Required(ErrorMessage = "Годината е задължителна.")]
        public int CaseYear { get; set; }

        [Display(Name = "Съдебна инстанция")]
        [MaxLength(50, ErrorMessage = "Съдебната инстатнция може да съдържа до 50 знака.")]
        [MinLength(2,ErrorMessage ="Съдебната инстатнция трябва да съдържа поне 2 знака.")]
        [Required(ErrorMessage = "Полето Съдебна инстанция е задължително.")]
        public string CourtChamber { get; set; }

        [Display(Name = "Вид дело")]
        public string CaseType { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CourtTypes { get; set; }
    }
}
