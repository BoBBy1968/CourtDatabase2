using CourtDatabase2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class CaseActionsEditViewModel
    {
        public int Id { get; set; }

        public int LegalActionId { get; set; }
        public virtual LegalAction LegalAction { get; set; }

        public int LawCaseId { get; set; }
        public virtual LawCase LawCase { get; set; }

        public string Debitor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LegalActions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }

    }
}
