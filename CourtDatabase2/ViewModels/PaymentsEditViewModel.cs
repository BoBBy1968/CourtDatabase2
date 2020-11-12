using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class PaymentsEditViewModel
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string PaymentSource { get; set; }

        public int LawCaseId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }
    }
}
