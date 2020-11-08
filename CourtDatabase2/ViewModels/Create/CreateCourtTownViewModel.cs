using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels.Create.CourtTown
{
    public class CreateCourtTownViewModel
    {
        [Required]
        [MaxLength(20)]
        public string TownName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
    }
}
