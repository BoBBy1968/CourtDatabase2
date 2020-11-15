using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class ExecutorsCasesCreateViewModel
    {
        public int ExecutorId { get; set; }

        public int LawCaseId { get; set; }

        [Range(0, 100_000)]
        public int? ExecutorCaseNumber { get; set; }

        [Range(2000, 2100)]
        public int? Year { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Executors { get; set; }
        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }
    }
}
