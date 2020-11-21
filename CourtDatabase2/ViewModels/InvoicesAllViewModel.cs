using System;
using CourtDatabase2.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CourtDatabase2.ViewModels
{
    public class InvoicesAllViewModel
    {
        public int Id { get; set; }

        public string Number { get; set; } // № на фактурата

        public DateTime IssueDate { get; set; }// Дата на издаване

        public decimal Value { get; set; } // Стойност

        public DateTime Maturity { get; set; } // Падеж

        public DateTime PeriodFrom { get; set; } // Период от

        public DateTime PeriodTo { get; set; } // Период до

        public string AbNumber { get; set; }
        public virtual HeatEstate HeatEstate { get; set; } // Топлоснабден обект

        public int DebitorId { get; set; }
        public virtual Debitor Debitor { get; set; } // Длъжник

        public string Condition { get; set; }
    }
}
