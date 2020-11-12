using CourtDatabase2.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.ViewModels
{
    public class LawCasesAllViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual Debitor Debitor { get; set; }

        public virtual HeatEstate HeatEstate { get; set; }

        [Range(0, 79228162514264337593543935D)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MoratoriumInterest { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LegalInterest { get; set; }

        [Range(0, int.MaxValue)]
        public int InvoiceCount { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodTo { get; set; }
    }
}
