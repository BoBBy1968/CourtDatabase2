using CourtDatabase2.Data.Models;

namespace CourtDatabase2.ViewModels
{
    public class ExecutorsCasesAllViewModel
    {
        public int Id { get; set; }

        public Executor Executor { get; set; }

        public LawCase LawCase { get; set; }

        public Debitor Debitor { get; set; }

        public int? ExecutorCaseNumber { get; set; }

        public int? Year { get; set; }
    }
}
