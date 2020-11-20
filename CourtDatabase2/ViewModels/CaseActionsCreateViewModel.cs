using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class CaseActionsCreateViewModel
    {
        public int LegalActionId { get; set; }

        public int LawCaseId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        public IEnumerable<KeyValuePair<string, string>> LegalActions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }

    }
}
