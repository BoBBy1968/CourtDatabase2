using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Areas.DebitorsCases.Models
{
    public class CaseActionsReportViewModel
    {
        public int LawCaseId { get; set; }

        public string DebitorName { get; set; }

        public decimal CaseValue { get; set; }

        public IEnumerable<CaseActionsAllViewModel> AllActions { get; set; }
    }
}
