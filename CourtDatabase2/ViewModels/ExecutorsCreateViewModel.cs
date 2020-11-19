using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class ExecutorsCreateViewModel
    {
        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(300,ErrorMessage = "Името може да бъде до 300 знака.")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Адреса може да бъде до 300 знака.")]
        [Required(ErrorMessage = "Адреса е задължителен.")]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "Телефона може да бъде до 50 знака.")]
        public string Telephon { get; set; }

        [MaxLength(200, ErrorMessage = "Имела може да бъде до 200 знака.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Номера е задължителен.")]
        [MaxLength(5, ErrorMessage = "Номера може да бъде до 5 знака.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Региона е задължителен.")]
        [MaxLength(20, ErrorMessage = "Региона може да бъде до 20 знака.")]
        public string Region { get; set; }
    }
}
