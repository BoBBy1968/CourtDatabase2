using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class Debitor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string EGN { get; set; }

        [ForeignKey(nameof(HeatEstate))]
        [MaxLength(11)]
        public string AbNumber { get; set; }
        public virtual HeatEstate HeatEstate { get; set; }

        [MaxLength(150)]
        public string AddressToContact { get; set; }

        [MaxLength(13)]
        public string Phone { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(150)]
        public string Representative { get; set; }

        public virtual ICollection<LawCase> LawCases => new HashSet<LawCase>();

    }
}
