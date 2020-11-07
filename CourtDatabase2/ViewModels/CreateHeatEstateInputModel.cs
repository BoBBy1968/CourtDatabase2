using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class CreateHeatEstateInputModel
    {
        [Required]
        public string AbNumber { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
