using System;

namespace CourtDatabase2.Areas.DebitorsCases.Models
{
    public class DebitorsCasesAllViewModel
    {
        public int Id { get; set; }

        public string AbNumber { get; set; }

        public int DebitorId { get; set; }

        public string Name { get; set; }

        public string EGN { get; set; }

        public string AddressEstate { get; set; }

        public string AddressDebitor { get; set; }

        public decimal MainValue { get; set; }

        public decimal MoratoriumInterest { get; set; }

        public decimal LegalInterest { get; set; }

        public decimal TotalValue => this.MainValue + this.MoratoriumInterest + this.LegalInterest;

        public DateTime PeriodFrom { get; set; }

        public DateTime PeriodTo { get; set; }

        public int InvoiceCount { get; set; }
    }
}
