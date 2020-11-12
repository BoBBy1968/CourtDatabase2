using CourtDatabase2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.ViewModels
{
    public class PaymentsAllViewModel
    {
        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public string PaymentSource { get; set; }

        public int LawCaseId { get; set; }
        
        public LawCase LawCase { get; set; }
    }
}
