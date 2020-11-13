using System;

namespace CourtDatabase2.ViewModels
{
    public class ExpenseAllViewModel
    {
        public int Id { get; set; }

        public string Payee { get; set; }

        public string ExpenceDescription { get; set; }

        public decimal ExpenceValue { get; set; }

        public string ExpenceDate { get; set; }

        public int LawCaseId { get; set; }
    }
}
