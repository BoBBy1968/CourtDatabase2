using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.Data.Models
{
    public class LegalAction
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(50)]
        public string ActionName { get; set; }

        public virtual ICollection<CaseAction> Cases => new HashSet<CaseAction>();
    }
}
