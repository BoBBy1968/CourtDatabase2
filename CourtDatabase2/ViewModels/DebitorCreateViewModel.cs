using CourtDatabase2.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class DebitorCreateViewModel
    {
        [Required]
        [MaxLength(250)]
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

        [MaxLength(11)]
        [Display(Name = "Абонатен номер")]
        public string AbNumber { get; set; }

        [Display(Name = "Имот")]
        public virtual HeatEstate HeatEstate { get; set; }

        [MaxLength(150)]
        [Display(Name = "Адрес за контакт")]
        public string AddressToContact { get; set; }

        [MaxLength(13)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }

        [MaxLength(150)]
        [Display(Name = "Представител")]
        public string Representative { get; set; }
    }
}
