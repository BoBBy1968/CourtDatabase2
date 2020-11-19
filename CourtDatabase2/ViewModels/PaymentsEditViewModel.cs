using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class PaymentsEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Стойността е задължителна.")]
        [Range(0.01, 79228162514264337593543950335d, ErrorMessage ="Стойността трябва да е положително число.")]
        public decimal Value { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        public string PaymentSource { get; set; }

        public int LawCaseId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }
    }
}
