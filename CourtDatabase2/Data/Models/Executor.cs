using CourtDatabase2.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.Data.Models
{
    public class Executor
    {
        [Key]
        public int Id { get; set; }

        public ExecutorMan CHSIExecutor { get; set; }

        public ICollection<ExecutorCase> ExecutorCases => new HashSet<ExecutorCase>();

    }
}