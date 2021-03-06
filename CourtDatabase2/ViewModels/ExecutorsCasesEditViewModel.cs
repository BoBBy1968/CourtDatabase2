﻿using CourtDatabase2.Data.Models;
using System.Collections.Generic;
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

        public Debitor Debitor { get; set; }

        [Range(0, 100_000)]
        public int? ExecutorCaseNumber { get; set; }

        [Range(2000, 2100)]
        public int? Year { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Executors { get; set; }
        public IEnumerable<KeyValuePair<string, string>> LawCases { get; set; }
    }
}
