using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.ViewModels
{
    public class ExpenseEditViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Получателят е задължителен.")]
        [MaxLength(50, ErrorMessage = "Получателят може да бъде до 50 знака.")]
        [MinLength(2, ErrorMessage = "Получателят трябва да бъде поне 2 знака.")]
        public string Payee { get; set; }

        [Required(ErrorMessage = "Описанието е задължително.")]
        [MaxLength(100, ErrorMessage = "Описанието може да бъде до 100 знака.")]
        [MinLength(3, ErrorMessage = "Описанието трябва да бъде поне 3 знака.")]
        public string ExpenceDescription { get; set; }

        [Range(0.01, 100_000, ErrorMessage = "Стойността трябва да бъде положително число до 100 000.")]
        [Required(ErrorMessage ="Стойността е задължителна.")]
        public decimal ExpenceValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpenceDate { get; set; } = DateTime.Now.Date;

        public int LawCaseId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }
    }
}
