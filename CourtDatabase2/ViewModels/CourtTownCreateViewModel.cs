using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class CourtTownCreateViewModel
    {
        [Required(ErrorMessage = "Името на града е задъжително за попълване.")]
        [MinLength(3, ErrorMessage = "Името на града не може да бъде по-малко от 3 символа")]
        [MaxLength(50, ErrorMessage = "Името на града не може да бъде по-дълго от 50 символа")]
        public string TownName { get; set; }

        [Required(ErrorMessage = "Адресът на града е задължителен за попълване.")]
        [MinLength(3, ErrorMessage = "Aдресът не може да бъде по-малък от 3 символа")]
        [MaxLength(300, ErrorMessage = "Адресът не може да бъде по-дълъг от 300 знака.")]
        public string Address { get; set; }
    }
}
