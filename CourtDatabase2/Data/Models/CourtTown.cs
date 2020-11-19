using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.Data.Models
{
    public class CourtTown
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string TownName { get; set; }

        [Required]
        [MaxLength(300)]
        public string Address { get; set; }

        public virtual ICollection<Court> Courts => new HashSet<Court>();
    }
}
