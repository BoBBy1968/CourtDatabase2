using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class HeatEstateEditViewModel
    {
        [Required(ErrorMessage = "Абонатния номер е задължителен.")]
        [MaxLength(11, ErrorMessage = "Абонатния номер може да бъде до 11 знака.")]
        [MinLength(3, ErrorMessage = "Абонатния номер трябва да бъде поне 3 знака.")]
        public string AbNumber { get; set; }

        [Required(ErrorMessage = "Адресът е задължителен.")]
        [MaxLength(150, ErrorMessage = "Адресът може да бъде до 150 знака.")]
        [MinLength(5, ErrorMessage = "Адресът трябва да бъде поне 5 знака.")]
        public string Address { get; set; }
    }
}
