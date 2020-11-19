using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class CourtTownEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името на града е задъжително за попълване.")]
        [MaxLength(50, ErrorMessage = "Името на града не може да бъде по-дълго от 50 символа")]
        [MinLength(3, ErrorMessage = "Името на града не може да бъде по-късо от 3 символа")]
        public string TownName { get; set; }

        [Required(ErrorMessage = "Адресът на града е задължителен за попълване.")]
        [MaxLength(300, ErrorMessage = "Адресът не може да бъде по-дълъг от 300 знака.")]
        public string Address { get; set; }
    }
}
