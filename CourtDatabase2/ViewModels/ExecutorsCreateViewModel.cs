using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class ExecutorsCreateViewModel
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(300)]
        [Required]
        public string Address { get; set; }

        [MaxLength(15)]
        public string Telephon { get; set; }

        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(5)]
        public string Number { get; set; }

        [Required]
        [MaxLength(20)]
        public string Region { get; set; }
    }
}
