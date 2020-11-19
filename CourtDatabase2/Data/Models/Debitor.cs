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
        [MaxLength(300)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Презиме")]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "ЕГН")]
        public string EGN { get; set; }

        [ForeignKey(nameof(HeatEstate))]
        [MaxLength(11)]
        [Display(Name = "Абонатен номер")]
        public string AbNumber { get; set; }

        [Display(Name = "Имот")]
        public virtual HeatEstate HeatEstate { get; set; }

        [MaxLength(300)]
        [Display(Name = "Адрес за контакт")]
        public string AddressToContact { get; set; }

        [MaxLength(50)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }

        [MaxLength(200)]
        [Display(Name = "Представител")]
        public string Representative { get; set; }

        public virtual ICollection<LawCase> LawCases => new HashSet<LawCase>();

    }
}
