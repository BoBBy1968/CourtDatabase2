using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels.CourtTown
{
    public class CreateCourtTownViewModel
    {
        [Required(ErrorMessage = "Името на града е задъжително за попълване.")]
        [MaxLength(20, ErrorMessage = "Името на града не може да бъде по-дълго от 20 символа")]
        public string TownName { get; set; }

        [Required(ErrorMessage = "Адресът на града е задължителен за попълване.")]
        [MaxLength(250, ErrorMessage = "Адресът не може да бъде по-дълъг от 250 знака.")]
        public string Address { get; set; }
    }
}
