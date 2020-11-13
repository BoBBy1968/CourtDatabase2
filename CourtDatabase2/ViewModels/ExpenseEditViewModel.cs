using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.ViewModels
{
    public class ExpenseEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Payee { get; set; }

        [Required]
        [MaxLength(100)]
        public string ExpenceDescription { get; set; }

        [Range(0.01, 100_000)]
        public decimal ExpenceValue { get; set; }

        public DateTime ExpenceDate { get; set; }

        public int LawCaseId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }
    }
}
