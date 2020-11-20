using CourtDatabase2.Data.Models;
using System;

namespace CourtDatabase2.ViewModels
{
    public class CaseActionsAllViewModel
    {
        public int Id { get; set; }

        public int LegalActionId { get; set; }
        public virtual LegalAction LegalAction { get; set; }

        public int LawCaseId { get; set; }
        public virtual LawCase LawCase { get; set; }

        public string Debitor { get;set; }

        public DateTime Date { get; set; }
    }
}
