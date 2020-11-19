using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.ViewModels
{
    public class LawCaseInputModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        public int DebitorId { get; set; }

        public string AbNumber { get; set; }

        [Range(0.01, 79228162514264337593543935D, ErrorMessage ="Главницата трябва да бъде положително число.")]
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Главницата е задължителна.")]
        public decimal Value { get; set; }

        [Range(0.01, 79228162514264337593543935D, ErrorMessage = "Мораторната трябва да бъде положително число.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MoratoriumInterest { get; set; }

        [Range(0.01, 79228162514264337593543935D, ErrorMessage = "Законовата лихва трябва да бъде положително число.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? LegalInterest { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Броят фактури трябва да бъде по-голям от 0.")]
        [Required(ErrorMessage = "Броят фактури е задължителен.")]
        public int InvoiceCount { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodTo { get; set; }

        public IEnumerable<KeyValuePair<string, string>> AbNumbers { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Debitors { get; set; }
    }
}
