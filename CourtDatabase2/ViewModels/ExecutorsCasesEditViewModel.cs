using CourtDatabase2.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class ExecutorsCasesEditViewModel
    {
        public int Id { get; set; }

        public int ExecutorId { get; set; }

        public Executor Executor { get; set; }

        public int LawCaseId { get; set; }
        
        public LawCase LawCase { get; set; }

        [Range(0, 100_000)]
        public int? ExecutorCaseNumber { get; set; }

        [Range(2000, 2100)]
        public int? Year { get; set; }
    }
}
