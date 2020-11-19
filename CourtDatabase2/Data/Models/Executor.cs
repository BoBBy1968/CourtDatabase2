using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.Data.Models
{
    public class Executor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength(300)]
        [Required]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Telephon { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(5)]
        public string Number { get; set; }

        [Required]
        [MaxLength(20)]
        public string Region { get; set; }

        public ICollection<ExecutorCase> ExecutorCases => new HashSet<ExecutorCase>();

    }
}