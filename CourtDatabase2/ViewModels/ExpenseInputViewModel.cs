using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.ViewModels
{
    public class ExpenseInputViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Payee { get; set; }

        [Required]
        [MaxLength(100)]
        public string ExpenceDescription { get; set; }

        [Range(0.01, 100_000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExpenceValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpenceDate { get; set; }

        public int LawCaseId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }
    }
}
