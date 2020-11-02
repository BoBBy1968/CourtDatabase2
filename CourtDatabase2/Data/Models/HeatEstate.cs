using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.Data.Models
{
    public class HeatEstate
    {
        [Key]
        [MaxLength(11)]
        public string AbNumber { get; set; }

        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

        public virtual ICollection<Debitor> Debitors => new HashSet<Debitor>();
    }
}