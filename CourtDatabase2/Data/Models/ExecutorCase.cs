using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class ExecutorCase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Executor))]
        public int ExecutorId { get; set; }
        public Executor Executor { get; set; }

        [ForeignKey(nameof(LawCase))]
        public int LawCaseId { get; set; }
        public LawCase LawCase { get; set; }

        [Range(1, 100_000)]
        public int? ExecutorCaseNumber { get; set; }

        [Range(2000, 2050)]
        public int? Year { get; set; } 
    }
}
