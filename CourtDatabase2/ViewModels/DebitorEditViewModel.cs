using CourtDatabase2.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class DebitorEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(250, ErrorMessage = "Името е до 250 знака.")]
        [MinLength(3, ErrorMessage = "Името е поне 3 знака.")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Името е до 50 знака.")]
        [Display(Name = "Презиме")]
        public string MiddleName { get; set; }

        [MaxLength(50, ErrorMessage = "Името е до 50 знака.")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ЕГН е задължително.")]
        [MaxLength(10, ErrorMessage = "ЕГН е 10 знака.")]
        [MinLength(6, ErrorMessage = "ЕГН е поне 6 знака.")]
        [Display(Name = "ЕГН")]
        public string EGN { get; set; }

        [MaxLength(11, ErrorMessage = "Абонатния номер е до 11 знака.")]
        [Display(Name = "Абонатен номер")]
        [Required(ErrorMessage = "Абонатния номер е задължителен.")]
        public string AbNumber { get; set; }

        [Display(Name = "Имот")]
        public virtual HeatEstate HeatEstate { get; set; }

        [MaxLength(300, ErrorMessage = "Адреса е до 300 знака.")]
        [Display(Name = "Адрес за контакт")]
        public string AddressToContact { get; set; }

        [MaxLength(50, ErrorMessage = "Телефона е до 50 знака.")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Електронната поща е до 100 знака.")]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }

        [MaxLength(200, ErrorMessage = "Представител е до 200 знака.")]
        [Display(Name = "Представител")]
        public string Representative { get; set; }

        public IEnumerable<KeyValuePair<string, string>> HeatEstates { get; set; }
    }
}
