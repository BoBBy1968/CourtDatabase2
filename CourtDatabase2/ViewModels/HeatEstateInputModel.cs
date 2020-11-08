using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class HeatEstateInputModel
    {
        [Required]
        public string AbNumber { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
