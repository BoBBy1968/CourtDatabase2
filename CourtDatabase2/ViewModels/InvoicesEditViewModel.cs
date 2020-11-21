using System;
using CourtDatabase2.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CourtDatabase2.ViewModels
{
    public class InvoicesEditViewModel
    {
        public int Id { get; set; }

        [MaxLength(10, ErrorMessage = "Номера може да бъде до 10 знака.")]
        [Required(ErrorMessage = "Номера е задължителен.")]
        public string Number { get; set; } // № на фактурата

        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }// Дата на издаване

        [Range(0, 79228162514264337593543935D, ErrorMessage = "Стойността трябва да бъде положително число.")]
        public decimal Value { get; set; } // Стойност

        [DataType(DataType.Date)]
        public DateTime Maturity { get; set; } // Падеж

        [DataType(DataType.Date)]
        public DateTime PeriodFrom { get; set; } // Период от

        [DataType(DataType.Date)]
        public DateTime PeriodTo { get; set; } // Период до

        public string AbNumber { get; set; }
        public virtual HeatEstate HeatEstate { get; set; } // Топлоснабден обект

        public int DebitorId { get; set; }
        public virtual Debitor Debitor { get; set; } // Длъжник

        [Required]
        [MaxLength(30, ErrorMessage = "Състоянието може да бъде до 30 знака.")]
        [MinLength(3, ErrorMessage = "Състоянието трябва да бъде поне 3 знака.")]
        public string Condition { get; set; }

        public IEnumerable<KeyValuePair<string, string>> AllDebitors { get; set; }

        public IEnumerable<KeyValuePair<string, string>> AllEstates { get; set; }
    }
}
