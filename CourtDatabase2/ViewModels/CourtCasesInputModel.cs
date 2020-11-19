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
        public int CaseNumber { get; set; }

        [Display(Name = "Дело година")]
        [Range(2000, 2050, ErrorMessage = "Годината на делото трябва да бъде число между 2000 и 2050.")]
        public int CaseYear { get; set; }

        [Display(Name = "Съдебна инстанция")]
        [MaxLength(50)]
        [MinLength(2)]
        [Required(ErrorMessage = "Полето Съдебна инстанция е задължително.")]
        public string CourtChamber { get; set; }

        [Display(Name = "Вид дело")]
        [MaxLength(20)]
        public string CaseType { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CourtTypes { get; set; }
    }
}
